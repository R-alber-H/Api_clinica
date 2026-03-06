public interface IMedicoService
{
    Medico RegistrarMedico(MedicoCreateDTO dTO);
    List<Medico> ListarMedicos();
    Medico BuscarPorId(int id);
    Medico ActualizarDatos(int id, MedicoUpdateDTO dto);
    int buscarMedicoSintomas(List<string> sintomas);
}