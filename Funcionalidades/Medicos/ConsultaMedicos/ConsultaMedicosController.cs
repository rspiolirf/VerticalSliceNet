using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Funcionalidades.Medicos.ConsultaMedicos;

namespace VerticalSlice.Funcionalidades.Medicos.ExcluiMedico
{
    [ApiController]
    public class ConsultaMedicosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultaMedicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/consultamedicos")]
        public async Task<IActionResult> ConsultaMedicos() =>
            Ok(await _mediator.Send(new ConsultaMedicosQuery()));
    }
}