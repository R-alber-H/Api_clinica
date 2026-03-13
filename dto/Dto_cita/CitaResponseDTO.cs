using TuProyecto.Enums;

public class CitaResponseDTO
{
    public int Id { get; set; }
    public PacienteInfoDTO Paciente { get; set; } = new PacienteInfoDTO();
    public MedicoInfoDTO Medico { get; set; } = new MedicoInfoDTO();
    public List<string> Sintomas { get; set; } = new List<string>();
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public EstadoCita Estado { get; set; }
    public DateTime FechaCreacion { get; set; } 
    public DateTime FechaActualizacion { get; set; }
}