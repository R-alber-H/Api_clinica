public interface IPacienteService
{
    Paciente RegistrarPaciente(PacienteCreateDTO dto);
    List<Paciente> ListarPacientes();
    Paciente BuscarPorId(int id);
    Paciente ActualizarDatos(int id, PacienteUpdateDTO dto);
}