public class CitaCreateDTO
{
    public int PacienteId { get; set; }
    public List<string> Sintomas { get; set; } = new();
}