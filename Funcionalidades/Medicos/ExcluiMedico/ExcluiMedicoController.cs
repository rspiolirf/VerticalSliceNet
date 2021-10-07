using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSlice.Funcionalidades.Medicos.ExcluiMedico
{
    [ApiController]
    public class ExcluiMedicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExcluiMedicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        [Route("api/v1/excluimedico/{Id}")]
        public async Task<IActionResult> ExcluiMedico([FromRoute]ExcluiMedicoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
