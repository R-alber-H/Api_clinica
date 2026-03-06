
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
}