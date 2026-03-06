using Microsoft.AspNetCore.Mvc;
namespace ApiClinica.Controller
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
            List<Medico> medicos = _medicoService.ListarMedicos();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public IActionResult getMedico(int id)
        {
            Medico medico = _medicoService.BuscarPorId(id);
            return Ok(medico);
        }

        [HttpPost]
        public IActionResult crearMedico(MedicoDTO dto)
        {
            Medico medico = _medicoService.RegistrarMedico(dto);
            return Created("", medico);
        }

        [HttpPut("{id}")]
        public IActionResult actualizarDatos(int id, MedicoUpdateDTO dto)
        {
            try
            {
                Medico medicoActualizado = _medicoService.ActualizarDatos(id, dto);
                return Ok(medicoActualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
