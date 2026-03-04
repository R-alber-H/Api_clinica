public class Clinica
{
    public string Nombre{get;set;} = "";
    public List<Paciente> Pacientes{get;set;} = new List<Paciente>();
    public List<Medico> Medicos{get;set;} = new List<Medico>();
    public List<Cita> Citas{get;set;} = new List<Cita>();
}