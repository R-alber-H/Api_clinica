using Microsoft.AspNetCore.Mvc;
namespace ApiClinica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public IActionResult getMedicos()
        {
            try
            {
                List<Medico> medicos = _medicoService.ListarMedicos();
                return Ok(medicos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult getMedico(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El id debe ser mayor que 0");
                Medico medico = _medicoService.BuscarPorId(id);
                return Ok(medico);
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
        public IActionResult crearMedico(MedicoCreateDTO dto)
        {
            try
            {
                Medico medico = _medicoService.RegistrarMedico(dto);
                return Created("", medico);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno en el servidor");
            }

        }

        [HttpPut("{id}")]
        public IActionResult actualizarDatos(int id, MedicoUpdateDTO dto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El id debe ser mayor que 0");
                Medico medicoActualizado = _medicoService.ActualizarDatos(id, dto);
                return Ok(medicoActualizado);
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

        [HttpDelete("{id}")]
        public IActionResult InhabilitarMedico(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El id debe ser mayor que 0");
                Medico medico = _medicoService.DesactivarMedico(id);
                return Ok(medico);
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
