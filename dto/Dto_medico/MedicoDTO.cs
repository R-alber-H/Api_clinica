using TuProyecto.Enums;

public class MedicoDTO
{
    public string Nombre { get; set; } = "" ;
    public string Apellido { get; set; } = "" ;
    public string Dni {get;set;} = "" ;
    public string Correo{get;set;} = "" ;
    public int Edad { get; set; }
    public string Telefono { get; set; } = "" ;
    public Especialidad especialidad{get;set;}
    public List<string> palabrasClave{get;set;} = new List<string>();
}