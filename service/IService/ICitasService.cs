using TuProyecto.Enums;

public interface ICitasService
{
    CitaResponseDTO RegistrarCita(CitaCreateDTO dTO);
    List<CitaResponseDTO> ObtenerCitas();
    List<CitaResponseDTO> ObtenerCitaPaciente(int id);
    List<CitaResponseDTO> ObtenerCitaMedico(int id);
    CitaResponseDTO CambiarEstado(int id,EstadoCita estado);
    CitaResponseDTO ObtenerCitaPorId(int id);
}