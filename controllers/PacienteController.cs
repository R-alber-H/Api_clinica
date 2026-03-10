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
            try
            {
                List<Paciente> pacientes = _pacienteService.ListarPacientes();
                return Ok(pacientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getPaciente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que 0");
                }
                Paciente paciente = _pacienteService.BuscarPorId(id);

                return Ok(paciente);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpPost]
        public IActionResult CrearPaciente(PacienteCreateDTO dto)
        {
            try
            {
                Paciente paciente = _pacienteService.RegistrarPaciente(dto);
                return Created("", paciente);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPaciente(int id, PacienteUpdateDTO dto)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que 0");
                }
                Paciente pacienteActualizado = _pacienteService.ActualizarDatos(id, dto);
                return Ok(pacienteActualizado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }
    }
}
