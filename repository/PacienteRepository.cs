public class PacienteRepository
{
    private List<Paciente> Pacientes = new List<Paciente>();
    private int siguienteId = 1;

    public Paciente GuardarPaciente(Paciente paciente)
    {
        paciente.Id = siguienteId++;
        Pacientes.Add(paciente);
        return paciente;
    }

    public List<Paciente> ObtenerPacientes()
    {
        return Pacientes;
    }

    public Paciente? BuscarPorId(int id)
    {
        if(Pacientes.Count == 0)
        {
            return null;
        }
        foreach (var p in Pacientes)
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