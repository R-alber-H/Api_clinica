public class PacienteRepository
{
    private List<Paciente> pacientes = new List<Paciente>()
    {
        new Paciente { Id = 1, Nombre = "Ana", Apellido = "Lopez", Dni = "12345678", Edad = 25, Telefono = "987654321", Correo = "ana.lopez@example.com" },
        new Paciente { Id = 2, Nombre = "Juan", Apellido = "Perez", Dni = "87654321", Edad = 32, Telefono = "912345678", Correo = "juan.perez@example.com" },
        new Paciente { Id = 3, Nombre = "Maria", Apellido = "Gomez", Dni = "11223344", Edad = 40, Telefono = "923456789", Correo = "maria.gomez@example.com" }
    };
    
    private int id;

    public Paciente GuardarPaciente(Paciente paciente)
    {
        id = pacientes.Max(p => p.Id) + 1;
        paciente.Id = id;
        pacientes.Add(paciente);
        return paciente;
    }

    public List<Paciente> ObtenerPacientes()
    {
        return pacientes;
    }

    public Paciente? BuscarPorId(int id)
    {
        if(pacientes.Count == 0)
        {
            return null;
        }
        foreach (Paciente p in pacientes)
        {
            if(p.Id == id)
            {
                return p;
            }
        }
        return null;
    }

    public Paciente? ActualizarDatos(int id, PacienteUpdateDTO dto)
    {
        Paciente? pacienteEncontrado = BuscarPorId(id);
        if (pacienteEncontrado == null)
        {
            return pacienteEncontrado;
        }
        pacienteEncontrado.Nombre = dto.Nombre;
        pacienteEncontrado.Apellido = dto.Apellido;
        
        return pacienteEncontrado;
    }
}