
using TuProyecto.Enums;

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
        List<Medico> medicos = repository.ObtenerMedicos();
        return medicos;
    }

    public Medico RegistrarMedico(MedicoCreateDTO dto)
    {
        if (MedicoRegistradoConDni(dto.Dni))
        {
            throw new ArgumentException($"Ya existe un medico registrado con el DNI {dto.Dni}");
        }
        Medico medico = new Medico
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Correo = dto.Correo,
            Dni = dto.Dni,
            Edad = dto.Edad,
            Especialidad = dto.especialidad,
            Telefono = dto.Telefono,
            PalabrasClaves = dto.palabrasClave
        };
        return repository.GuardarMedico(medico);
    }

    public Medico BuscarMedicoSintomas(List<string> sintomas)
    {
        List<Medico> medicos = ListarMedicos();
        if (sintomas.Count == 0)
        {
            return BuscarMedicoGeneral();
        }
        foreach (var medico in medicos)
        {
            if (!medico.Activo)
            {
                continue;
            }
            foreach (var sintoma in medico.PalabrasClaves)
            {
                foreach (var sintomaPaciente in sintomas)
                {
                    if (sintoma.Trim().ToUpper() == sintomaPaciente.Trim().ToUpper())
                    {
                        return medico;
                    }
                }
            }
        }
       return BuscarMedicoGeneral();
    }

    private Medico BuscarMedicoGeneral()
    {
        List<Medico> medicos = ListarMedicos();
        foreach (Medico medico in medicos)
        {
            if (!medico.Activo)
            {
                continue;
            }
            if(medico.Especialidad == Especialidad.MedicinaGeneral)
            {
                return medico;
            }
        }
        throw new ArgumentException ("No hay médico general disponible");
    }

    public Medico DesactivarMedico(int id)
    {
        Medico medico = BuscarPorId(id);
        if (!medico.Activo)
        {
            throw new ArgumentException ("El medico ya esta inactivo");
        }
        medico.Activo = false;
        return medico;
    }

    private bool MedicoRegistradoConDni(string dni)
    {
        List<Medico> medicos = ListarMedicos();
        foreach (Medico medico in medicos)
        {
            if(medico.Dni == dni)
            {
                return true;
            }
        }
        return false;
    }
}