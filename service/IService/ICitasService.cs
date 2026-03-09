using TuProyecto.Enums;

public interface ICitasService
{
    CitaResponseDTO RegistrarCita(CitaCreateDTO dTO);
    List<Cita> ObtenerCitas();
    List<Cita> ObtenerCitaPaciente(int id);
    List<Cita> ObtenerCitaMedico(int id);
    Cita CambiarEstado(int id,EstadoCita estado);
    Cita ObtenerCitaPorId(int id);
}