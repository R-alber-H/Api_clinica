using TuProyecto.Enums;
public class CitaService : ICitasService
{
     private readonly CitaRepository repositoryCita;
     private readonly PacienteRepository repositoryPaciente;
     private readonly IMedicoService serviceMedico;

    public CitaService(CitaRepository repoCita, PacienteRepository repoPaciente, IMedicoService medicoService)
    {
        repositoryCita = repoCita;
        repositoryPaciente = repoPaciente;
        serviceMedico = medicoService;
    }
    public Cita cambiarEstado(int id)
    {
        throw new NotImplementedException();
    }

    public Cita registrarCita(CitaCreateDTO dto)
    {
        Paciente? paciente = repositoryPaciente.BuscarPorId(dto.PacienteId);
        if(paciente == null)
        {
            throw new ArgumentException("El paciente no esta registrado");
        }
        int idMedico = serviceMedico.buscarMedicoSintomas(dto.Sintomas);
        DateTime fechaInicio = obtenerProximaHoraDisponible(idMedico);
        DateTime fechaFin = fechaInicio.AddHours(1);

        Cita cita = new Cita
        {
            IdPaciente = dto.PacienteId,
            IdMedico = idMedico,
            Sintomas = dto.Sintomas,
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            Estado = EstadoCita.Pendiente
        };
        return repositoryCita.guardarCita(cita);
    }

    public List<Cita> obtenerCitaMedico(int id)
    {
        List<Cita>? citas = repositoryCita.obtenerCitaMedico(id);
        if(citas != null)
        {
            return citas;
        }
        return new List<Cita>();
    }

    public List<Cita> obtenerCitaPaciente(int id)
    {
        List<Cita>? citas = repositoryCita.obtenerCitaPaciente(id);
        if(citas != null) return citas;
        return new List<Cita>();
    }

    public List<Cita> obtenerCitas()
    {
        List<Cita>? citas = repositoryCita.obtenerCitas();
        if(citas != null)
        {
            return citas;
        }
        return new List<Cita>();
    }

    public DateTime obtenerProximaHoraDisponible(int idMedico)
    {
        List<Cita> citas = obtenerCitaMedico(idMedico);
        DateTime ultimaFechaFin = DateTime.Today.AddHours(7);    
        foreach (var cita in citas)
        {
            if(cita.FechaFin > ultimaFechaFin)
            {
                ultimaFechaFin = cita.FechaFin;
            }
        }
        return ultimaFechaFin;
    }
}