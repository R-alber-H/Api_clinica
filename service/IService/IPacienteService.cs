public interface IPacienteService
{
    Paciente RegistrarPaciente(PacienteDTO dto);
    List<Paciente> ListarPacientes();
    Paciente BuscarPorId(int id);
    Paciente ActualizarDatos(int id, PacienteUpdateDTO dto);
}