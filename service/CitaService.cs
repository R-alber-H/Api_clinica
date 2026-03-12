using Microsoft.AspNetCore.Mvc;
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
    public CitaResponseDTO CambiarEstado(int id, EstadoCita estado)
    {
        Cita? cita = repositoryCita.ObtenerCitaId(id);
        if (cita == null)
        {
            throw new ArgumentException("Cita no encontrada");
        }
        if (cita.Estado != EstadoCita.Pendiente)
        {
            throw new ArgumentException("Solo se pueden modificar citas pendientes");
        }
        cita.Estado = estado;
        cita.FechaActualizacion = DateTime.Now;
        Paciente paciente = servicePaciente.BuscarPorId(cita.IdPaciente);
        Medico medico = serviceMedico.BuscarPorId(cita.IdMedico);
        CitaResponseDTO citaActualizada = ConvertirACitaResponseDTO(cita, paciente, medico);
        return citaActualizada;
    }
    public CitaResponseDTO ObtenerCitaPorId(int id)
    {
        Cita? cita = repositoryCita.ObtenerCitaId(id);
        if (cita == null)
        {
            throw new ArgumentException("Cita no encontrada");
        }
        Paciente paciente = servicePaciente.BuscarPorId(cita.IdPaciente);
        Medico medico = serviceMedico.BuscarPorId(cita.IdMedico);

        return ConvertirACitaResponseDTO(cita, paciente, medico);
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

    public List<CitaResponseDTO> ObtenerCitaMedico(int id)
    {
        List<Cita>? citas = repositoryCita.ObtenerCitaMedico(id);
        if (citas != null)
        {
            List<CitaResponseDTO> citasmedicos = new List<CitaResponseDTO>();
            foreach (var cita in citas)
            {
                Paciente paciente = servicePaciente.BuscarPorId(cita.IdPaciente);
                Medico medico = serviceMedico.BuscarPorId(cita.IdMedico);
                CitaResponseDTO citaNueva = ConvertirACitaResponseDTO(cita, paciente, medico);
                citasmedicos.Add(citaNueva);
            }
            return citasmedicos;
        }
        return new List<CitaResponseDTO>();
    }

    public List<CitaResponseDTO> ObtenerCitaPaciente(int id)
    {
        List<Cita>? citas = repositoryCita.ObtenerCitaPaciente(id);
        if (citas != null)
        {
            List<CitaResponseDTO> citasPacientes = new List<CitaResponseDTO>();
            foreach (var cita in citas)
            {
                Paciente paciente = servicePaciente.BuscarPorId(cita.IdPaciente);
                Medico medico = serviceMedico.BuscarPorId(cita.IdMedico);
                CitaResponseDTO citaNueva = ConvertirACitaResponseDTO(cita, paciente, medico);
                citasPacientes.Add(citaNueva);
            }
            return citasPacientes;
        }
        return new List<CitaResponseDTO>();
    }

    public List<CitaResponseDTO> ObtenerCitas()
    {
        List<Cita> citas = repositoryCita.ObtenerCitas();

        List<CitaResponseDTO> citasNuevas = new List<CitaResponseDTO>();
        foreach (var cita in citas)
        {
            Paciente paciente = servicePaciente.BuscarPorId(cita.IdPaciente);
            Medico medico = serviceMedico.BuscarPorId(cita.IdMedico);
            CitaResponseDTO citaNueva = ConvertirACitaResponseDTO(cita, paciente, medico);
            citasNuevas.Add(citaNueva);
        }
        return citasNuevas;

    }

    public DateTime ObtenerProximaHoraDisponible(int idMedico)
    {
        List<Cita> citas = repositoryCita.ObtenerCitaMedico(idMedico);
        if (citas.Count == 0)
        {
            return DateTime.Today.AddHours(7);
        }
        DateTime ultimaFechaFin = DateTime.Today.AddHours(7);
        foreach (var cita in citas)
        {
            if (cita.FechaFin > ultimaFechaFin)
            {
                ultimaFechaFin = cita.FechaFin;
            }
        }
        if(ultimaFechaFin >= DateTime.Today.AddHours(17))
        {
            
            ultimaFechaFin = DateTime.Today.AddDays(1).AddHours(7);
        }
        return ultimaFechaFin;
    }

    private CitaResponseDTO ConvertirACitaResponseDTO(Cita cita, Paciente paciente, Medico medico)
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
            Estado = cita.Estado,
            FechaCreacion = cita.FechaCreacion,
            FechaActualizacion = cita.FechaActualizacion
        };
        return nuevaCita;
    }
}