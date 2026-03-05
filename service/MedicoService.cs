
public class MedicoService : IMedicoService
{
    private readonly MedicoRepository repository;

    public MedicoService(MedicoRepository repo)
    {
        repository = repo;
    }

    public Medico ActualizarDatos(int id, MedicoUpdateDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre))
            throw new ArgumentException("El nombre es obligatorio");

        if (string.IsNullOrWhiteSpace(dto.Apellido))
            throw new ArgumentException("El apellido es obligatorio");
        
        Medico? medicoActualizado = repository.ActualizarDatos(id,dto);
        if(medicoActualizado != null)
        {
            return medicoActualizado;
        }
        throw new ArgumentException("Medico no registrado");
    }

    public Medico BuscarPorId(int id)
    {
        Medico? medico = repository.BuscarPorId(id);
        if(medico != null)
        {
            return medico;
        }
        throw new ArgumentException("Medico no encontrado");
    }

    public List<Medico> ListarMedicos()
    {
        List<Medico>? medicos = repository.ObtenerMedicos();
        if (medicos != null)
        {
            return medicos;
        }
        throw new ArgumentException("No hay medicos registrados");
    }

    public Medico RegistrarMedico(MedicoDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre))
            throw new ArgumentException("El nombre es obligatorio");

        if (dto.Edad <= 0)
            throw new ArgumentException("La edad debe ser mayor a cero");
        
        Medico medico = new Medico
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Correo = dto.Correo,
            Dni = dto.Dni,
            Edad = dto.Edad
        };
        return repository.GuardarMedico(medico);
    }

    public int buscarMedicoSintomas(List<string> sintomas)
    {
        List<Medico> medicos = ListarMedicos();
        foreach (var medico in medicos)
        {
            foreach (var sintoma in medico.PalabrasClaves)
            {
                foreach (var sintomaPaciente in sintomas)
                {
                    if (sintoma == sintomaPaciente)
                    {
                        return medico.Id;
                    }
                }
            }
        }return medicos[0].Id;
    }

}