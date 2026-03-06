
public class MedicoService : IMedicoService
{
    private readonly MedicoRepository repository;

    public MedicoService(MedicoRepository repo)
    {
        repository = repo;
    }

    public Medico ActualizarDatos(int id, MedicoUpdateDTO dto)
    {
        Medico? medicoActualizado = repository.ActualizarDatos(id, dto);
        if (medicoActualizado == null)
        {
           throw new ArgumentException("Medico no Registrado");
        }
        return medicoActualizado;
        
    }

    public Medico BuscarPorId(int id)
    {
        Medico? medico = repository.BuscarPorId(id);
        if (medico == null)
        {
             throw new ArgumentException("Medico no Registrado");
        }
        return medico;
    }

    public List<Medico> ListarMedicos()
    {
        List<Medico>? medicos = repository.ObtenerMedicos();
        if (medicos == null)
        {
            return new List<Medico>();
        }
        return medicos;
    }

    public Medico RegistrarMedico(MedicoCreateDTO dto)
    {
        Medico medico = new Medico
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Correo = dto.Correo,
            Dni = dto.Dni,
            Edad = dto.Edad,
            Especialidad = dto.especialidad,
            PalabrasClaves = dto.palabrasClave
        };
        return repository.GuardarMedico(medico);
    }

    public int buscarMedicoSintomas(List<string> sintomas)
    {
        List<Medico> medicos = ListarMedicos();
        if (sintomas.Count == 0)
        {
            return medicos[0].Id;
        }
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
        }
        return medicos[0].Id;
    }

}