using TuProyecto.Enums;

public class MedicoRepository
{
    private List<Medico> medicos = new List<Medico>()
    {
         new Medico
        {
            Id = 1,
            Nombre = "Carlos",
            Apellido = "Ramirez",
            Dni = "12345678",
            Edad = 45,
            Telefono = "987654321",
            Correo = "carlos.ramirez@example.com",
            Especialidad = Especialidad.Cardiologia,
            PalabrasClaves = new List<string> { "corazon", "presion", "arterias" }
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
            PalabrasClaves = new List<string> { "niños", "vacunas", "crecimiento" }
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
            Especialidad = Especialidad.Dermatologia,
            PalabrasClaves = new List<string> { "piel", "acne", "eczema" }
        }
    };
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
