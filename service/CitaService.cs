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

    public CitaResponseDTO RegistrarCita(CitaCreateDTO dto)
    {
        Paciente paciente = servicePaciente.BuscarPorId(dto.PacienteId);

        Medico medico = serviceMedico.BuscarMedicoSintomas(dto.Sintomas);
        DateTime fechaInicio = ObtenerProximaHoraDisponible(medico.Id);
        DateTime fechaFin = fechaInicio.AddHours(1);

        Cita cita = new Cita
        {
            IdPaciente = dto.PacienteId,
            IdMedico = medico.Id,
            Sintomas = dto.Sintomas,
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            Estado = EstadoCita.Pendiente
        };
        Cita citaRespuesta = repositoryCita.GuardarCita(cita);
        return ConvertirACitaResponseDTO(citaRespuesta, paciente, medico);
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

    private CitaResponseDTO ConvertirACitaResponseDTO(Cita cita,Paciente paciente,Medico medico)
    {
        CitaResponseDTO nuevaCita = new CitaResponseDTO
        {
            Id = cita.Id,
            Paciente = new PacienteInfoDTO
            {
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Dni = paciente.Dni
            },
            Medico = new MedicoInfoDTO
            {
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                Dni = medico.Dni,
                Especialidad = medico.Especialidad
            },
            Sintomas = cita.Sintomas,
            FechaInicio = cita.FechaInicio,
            FechaFin = cita.FechaFin,
            Estado = cita.Estado
        };
        return nuevaCita;
    }
}