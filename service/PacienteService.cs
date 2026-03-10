
public class PacienteService : IPacienteService
{
    private readonly PacienteRepository repository;

    public PacienteService(PacienteRepository repo)
    {
        repository = repo;
    }
    public Paciente ActualizarDatos(int id, PacienteUpdateDTO dto)
    {
        Paciente? pacienteActualizado = repository.ActualizarDatos(id, dto);

        if (pacienteActualizado == null)
        {
             throw new ArgumentException("El paciente no está registrado");
        }
        return pacienteActualizado;
    }

    public Paciente BuscarPorId(int id)
    {
        Paciente? paciente = repository.BuscarPorId(id);

        if (paciente == null)
        {
            throw new ArgumentException("Paciente no registrado");
        }
        return paciente;
    }

    public List<Paciente> ListarPacientes()
    {
        List<Paciente> ListaPacientes = repository.ObtenerPacientes();
        if (ListaPacientes.Count == 0)
        {
            return new List<Paciente>();
        }
        return ListaPacientes;
    }

    public Paciente RegistrarPaciente(PacienteCreateDTO dto)
    {
        if (PacienteRegistradoConDni(dto.Dni))
        {
            throw new ArgumentException($"Ya existe un paciente registrado con el DNI {dto.Dni}");
        }
        Paciente paciente = new Paciente
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Edad = dto.Edad,
            Telefono = dto.Telefono,
            Correo = dto.Correo,
            Dni = dto.Dni
        };

        return repository.GuardarPaciente(paciente);
    }

    private bool PacienteRegistradoConDni(string dni)
    {
        List<Paciente> pacientes = repository.ObtenerPacientes();
        foreach (Paciente paciente in pacientes)
        {
            if(paciente.Dni == dni)
            {
                return true;
            }
        }
        return false;
    }
}