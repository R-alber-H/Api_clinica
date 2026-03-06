using Microsoft.AspNetCore.Mvc;
using TuProyecto.Enums;
namespace ApiClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ICitasService _citaService;
        public CitaController(ICitasService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public IActionResult getCitas()
        {
            try
            {
                List<Cita> citas = _citaService.obtenerCitas();
                return Ok(citas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpPost]
        public IActionResult crearCita(CitaCreateDTO dto)
        {
            try
            {
                Cita cita = _citaService.registrarCita(dto);
                return Created("", cita);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404,ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpPut("{id}")]
        public IActionResult cambiarEstado(int id, EstadoCita estado)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que 0");
                }
                Cita citaActualizada = _citaService.cambiarEstado(id,estado);
                return Ok(citaActualizada);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404,ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }
    }
}