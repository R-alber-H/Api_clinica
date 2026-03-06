using TuProyecto.Enums;
public class CitaService : ICitasService
{
    private readonly CitaRepository repositoryCita;
    private readonly IPacienteService servicePaciente;
    private readonly IMedicoService serviceMedico;

    public CitaService(CitaRepository repoCita, IMedicoService medicoService, IPacienteService pacienteService)
    {
        repositoryCita = repoCita;
        serviceMedico = medicoService;
        servicePaciente = pacienteService;
    }
    public Cita CambiarEstado(int id, EstadoCita estado)
    {
        Cita cita = ObtenerCitaPorId(id);
        cita.Estado = estado;
        return cita;

    }
    public Cita ObtenerCitaPorId(int id)
    {
        Cita? cita = repositoryCita.ObtenerCitaId(id);
        if (cita == null)
        {
            throw new ArgumentException("Cita no encontrada");
        }
        return cita;
    }

    public Cita RegistrarCita(CitaCreateDTO dto)
    {
        servicePaciente.BuscarPorId(dto.PacienteId);

        int idMedico = serviceMedico.BuscarMedicoSintomas(dto.Sintomas);
        DateTime fechaInicio = ObtenerProximaHoraDisponible(idMedico);
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
        return repositoryCita.GuardarCita(cita);
    }

    public List<Cita> ObtenerCitaMedico(int id)
    {
        List<Cita>? citas = repositoryCita.ObtenerCitaMedico(id);
        if (citas != null)
        {
            return citas;
        }
        return new List<Cita>();
    }

    public List<Cita> ObtenerCitaPaciente(int id)
    {
        List<Cita>? citas = repositoryCita.ObtenerCitaPaciente(id);
        if (citas != null) return citas;
        return new List<Cita>();
    }

    public List<Cita> ObtenerCitas()
    {
        List<Cita>? citas = repositoryCita.ObtenerCitas();
        if (citas != null)
        {
            return citas;
        }
        return new List<Cita>();
    }

    public DateTime ObtenerProximaHoraDisponible(int idMedico)
    {
        List<Cita> citas = ObtenerCitaMedico(idMedico);
        DateTime ultimaFechaFin = DateTime.Today.AddHours(7);
        foreach (var cita in citas)
        {
            if (cita.FechaFin > ultimaFechaFin)
            {
                ultimaFechaFin = cita.FechaFin;
            }
        }
        return ultimaFechaFin;
    }
}