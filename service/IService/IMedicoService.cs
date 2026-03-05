public interface IMedicoService
{
    Medico RegistrarMedico(MedicoDTO medico);
    List<Medico> ListarMedicos();
    Medico BuscarPorId(int id);
    Medico ActualizarDatos(int id, MedicoUpdateDTO dto);
}