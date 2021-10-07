using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Filtros;

namespace VerticalSlice.Funcionalidades.Medicos.AdicionaMedico
{
    [ApiController]
    public class AdicionaMedicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdicionaMedicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/v1/adicionamedico")]
        [ModelValidationAttribute]
        public async Task<IActionResult> InsereMedico(AdicionaMedicoCommand command)
        {
            var result = await _mediator.Send(command);
            return Created($"api/medicos/{result.Id}", result);
        }
    }
}
