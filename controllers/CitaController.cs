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
                List<CitaResponseDTO> citas = _citaService.ObtenerCitas();
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
                CitaResponseDTO cita = _citaService.RegistrarCita(dto);
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
        public IActionResult cambiarEstado(int id, [FromBody] CambiarEstadoDTO dTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que 0");
                }
                CitaResponseDTO citaActualizada = _citaService.CambiarEstado(id,dTO.Estado);
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

        [HttpGet("{id}")]
        public IActionResult obtenerCita(int id)
        {
            try
            {
               if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor que 0");
                }
                CitaResponseDTO cita = _citaService.ObtenerCitaPorId(id);
                return Ok(cita); 
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404,ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500,"Ocurrio un error interno en el servidor");
            }
        }
    }
}