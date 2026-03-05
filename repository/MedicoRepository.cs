public class MedicoRepository
{
    private List<Medico> medicos = new List<Medico>();
    private int siguienteId = 1;

    public Medico GuardarMedico(Medico medico)
    {
        medico.Id = siguienteId;
        siguienteId ++;
        medicos.Add(medico);
        return medico;
    }

    public List<Medico>? ObtenerMedicos()
    {
        if(medicos.Count != 0)
        {
            return medicos;
        }
        return null;
    }

    public Medico? BuscarPorId(int id)
    {
        foreach (var m in medicos)
        {
            if(m.Id == id)
            {
                return m;
            }
        }
        return null;
    }

    public Medico? ActualizarDatos(int id, MedicoUpdateDTO dto)
    {
        Medico? medico = BuscarPorId(id);
        if(medico != null)
        {
            medico.Nombre = dto.Nombre;
            medico.Apellido = dto.Apellido;
            return medico;
        }
        return medico;
    }
}
