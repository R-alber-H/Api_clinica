using Microsoft.AspNetCore.Mvc;
namespace ApiClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public IActionResult getPacientes()
        {
            List<Paciente> pacientes = _pacienteService.ListarPacientes();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public IActionResult getPaciente(int id)
        {
            Paciente paciente = _pacienteService.BuscarPorId(id);
            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }

         [HttpPost]
         public IActionResult CrearPaciente(PacienteDTO dto)
        {
            Paciente paciente = _pacienteService.RegistrarPaciente(dto);
            return Created("", paciente);
        }
    }
}
