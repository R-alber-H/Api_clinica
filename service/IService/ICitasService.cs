using TuProyecto.Enums;

public interface ICitasService
{
    Cita registrarCita(CitaCreateDTO dTO);
    List<Cita> obtenerCitas();
    List<Cita> obtenerCitaPaciente(int id);
    List<Cita> obtenerCitaMedico(int id);
    Cita cambiarEstado(int id,EstadoCita estado);
    Cita obtenerCitaPorId(int id);
}