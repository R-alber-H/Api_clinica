
public class PacienteService : IPacienteService
{
    private readonly PacienteRepository repository;

    public PacienteService(PacienteRepository repo)
    {
        repository = repo;
    }
    public Paciente ActualizarDatos(int id, PacienteUpdateDTO dto)
{
    // Validaciones de reglas de negocio
    if (string.IsNullOrWhiteSpace(dto.Nombre))
        throw new ArgumentException("El nombre es obligatorio");
    
    if (string.IsNullOrWhiteSpace(dto.Apellido))
        throw new ArgumentException("El apellido es obligatorio");

    // Llamar al repository para actualizar
    Paciente? pacienteActualizado = repository.ActualizarDatos(id, dto);

    if (pacienteActualizado == null)
        throw new ArgumentException("El paciente no está registrado");

    return pacienteActualizado;
}

    public Paciente BuscarPorId(int id)
    {
        Paciente? paciente = repository.BuscarPorId(id);

        if(paciente == null)
        {
            throw new ArgumentException("Paciente no encontrado");
        }
        return paciente;
    }

    public List<Paciente> ListarPacientes()
    {
        List<Paciente> ListaPacientes = repository.ObtenerPacientes();
        if (ListaPacientes.Count == 0)
        {
            throw new ArgumentException ("No hay pacientes registrados");
        }
        return ListaPacientes;
    }

    public Paciente RegistrarPaciente(PacienteDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre))
            throw new ArgumentException("El nombre es obligatorio");

        if (dto.Edad <= 0)
            throw new ArgumentException("La edad debe ser mayor a cero");
        
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