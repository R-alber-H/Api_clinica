public class CitaRepository
{
    private List<Cita> citas = new List<Cita>();
    private int siguienteId = 1;

    public Cita GuardarCita(Cita cita)
    {
        cita.Id = siguienteId;
        citas.Add(cita);
        siguienteId++;
        return cita;
    }

    public List<Cita>? ObtenerCitas()
    {
        if(citas.Count != 0) return citas;
        return null;
    }

    public List<Cita>? ObtenerCitaPaciente(int id)
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

    public List<Cita>? ObtenerCitaMedico(int id)
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

    public Cita? ObtenerCitaId(int id)
    {
        foreach (Cita cita in citas)
        {
            if(cita.Id == id)
            {
                return cita;
            }
        }
        return null;
    }

}