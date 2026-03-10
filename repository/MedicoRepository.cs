using TuProyecto.Enums;

public class MedicoRepository
{
    private List<Medico> medicos = new List<Medico>()
    {
         new Medico
        {
            Id = 1,
            Nombre = "Mario",
            Apellido = "Ramirez",
            Dni = "12345678",
            Edad = 45,
            Telefono = "987654321",
            Correo = "carlos.ramirez@example.com",
            Especialidad = Especialidad.MedicinaGeneral,
            PalabrasClaves = new List<string>(),
            Activo= true
        },
        new Medico
        {
            Id = 2,
            Nombre = "Lucia",
            Apellido = "Martinez",
            Dni = "87654321",
            Edad = 38,
            Telefono = "912345678",
            Correo = "lucia.martinez@example.com",
            Especialidad = Especialidad.Pediatria,
            PalabrasClaves = new List<string> { "niños", "vacunas", "crecimiento" },
            Activo= true
        },
        new Medico
        {
            Id = 3,
            Nombre = "Andres",
            Apellido = "Gomez",
            Dni = "11223344",
            Edad = 50,
            Telefono = "923456789",
            Correo = "andres.gomez@example.com",
            Especialidad = Especialidad.Cardiologia,
            PalabrasClaves = new List<string> { "Palpitaciones", "Dolor en el pecho" },
            Activo= true
        }
    };
    private int id;

    public Medico GuardarMedico(Medico medico)
    {
        id = medicos.Max(m => m.Id)+1;
        medico.Id = id;
        medicos.Add(medico);
        return medico;
    }

    public List<Medico> ObtenerMedicos()
    {
        if(medicos.Count != 0)
        {
            return medicos;
        }
        return new List<Medico>();
    }

    public Medico? BuscarPorId(int id)
    {
        foreach (Medico m in medicos)
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
