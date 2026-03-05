public class PacienteRepository
{
    private List<Paciente> pacientes = new List<Paciente>();
    private int siguienteId = 1;

    public Paciente GuardarPaciente(Paciente paciente)
    {
        paciente.Id = siguienteId++;
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
        foreach (var p in pacientes)
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