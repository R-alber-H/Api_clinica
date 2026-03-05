public class CitaRepository
{
    private List<Cita> citas = new List<Cita>();
    private int siguienteId = 1;

    public Cita guardarCita(Cita cita)
    {
        cita.Id = siguienteId;
        citas.Add(cita);
        siguienteId++;
        return cita;
    }

    public List<Cita>? obtenerCitas()
    {
        if(citas.Count != 0) return citas;
        return null;
    }

    public List<Cita>? obtenerCitaPaciente(int id)
    {
        List<Cita> listaPacientes = new List<Cita>();
        foreach (var c in citas)
        {
            if(c.IdPaciente == id)
            {
                listaPacientes.Add(c);
            }
        }
        if(listaPacientes.Count != 0)
        {
            return listaPacientes;
        }
        return null;
    }

    public List<Cita>? obtenerCitaMedico(int id)
    {
        List<Cita> listaMedicos = new List<Cita>();
        foreach (var c in citas)
        {
            if(c.IdMedico == id)
            {
                listaMedicos.Add(c);
            }
        }
        if(listaMedicos.Count != 0)
        {
            return listaMedicos;
        }
        return null;
    }

}