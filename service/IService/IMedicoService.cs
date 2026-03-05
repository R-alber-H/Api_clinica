public interface IMedicoService
{
    Medico RegistrarMedico(Medico medico);
    List<Medico> ListarMedicos();
    Medico BuscarPorId(int id);
    Medico ActualizarDatos(int id, Medico medico);
}