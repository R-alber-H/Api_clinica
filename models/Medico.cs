using TuProyecto.Enums;

public class Medico : Persona
{
    public Especialidad Especialidad { get; set; }
    public List<string> PalabrasClaves { get; set; } = new List<string>();
}