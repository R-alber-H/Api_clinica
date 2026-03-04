using TuProyecto.Enums;

public class Cita
{
    public int Id { get; set; }
    public int IdPaciente{get;set;}
    public int IdMedico {get;set;}
    public List<string> Sintomas {get;set;} = new List<string>();
    public DateTime FechaInicio {get;set;}
    public DateTime FechaFin {get;set;}
    public EstadoCita Estado { get; set; }        
}