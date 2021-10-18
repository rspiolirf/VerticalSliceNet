using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSlice.Funcionalidades.Medicos.ConsultaMedicoPorId
{
    [ApiController]
    public class ConsultaMedicoPorIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultaMedicoPorIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/consultamedicoporid/{Id}")]
        public async Task<IActionResult> ConsultaMedicoPorId([FromRoute]ConsultaMedicoPorIdQuery query) => 
            Ok(await _mediator.Send(query));
    }
}
