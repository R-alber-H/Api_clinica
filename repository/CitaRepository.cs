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

    public List<Cita> ObtenerCitas()
    {
        return citas;
    }

    public List<Cita> ObtenerCitaPaciente(int id)
    {
        List<Cita> listaPacientes = new List<Cita>();
        foreach (var c in citas)
        {
            if(c.IdPaciente == id)
            {
                listaPacientes.Add(c);
            }
        }
        return listaPacientes;
    }

    public List<Cita> ObtenerCitaMedico(int id)
    {
        List<Cita> listaMedicos = new List<Cita>();
        foreach (var c in citas)
        {
            if(c.IdMedico == id)
            {
                listaMedicos.Add(c);
            }
        }
       return listaMedicos;
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