using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemMedicoPorId
{
    [ApiController]
    public class ObtemMedicoPorIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ObtemMedicoPorIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/obtemmedicoporid/{Id}")]
        public async Task<IActionResult> ObtemMedicoPorId([FromRoute]ObtemMedicoPorIdQuery query) => 
            Ok(await _mediator.Send(query));
    }
}
