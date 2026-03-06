using Microsoft.AspNetCore.Mvc;
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
            List<Cita> citas = _citaService.obtenerCitas();
            return Ok(citas);
        }

        [HttpPost]
        public IActionResult crearCita(CitaCreateDTO dto)
        {
            Cita cita = _citaService.registrarCita(dto);
            return Created("", cita);
        }
    }
}