using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Filtros;
using VerticalSlice.Funcionalidades.Medicos.AdicionaMedico;
using VerticalSlice.Funcionalidades.Medicos.ObtemMedicoPorId;
using VerticalSlice.Funcionalidades.Medicos.ObtemTodosMedicos;

namespace VerticalSlice.Funcionalidades.Medicos.ExcluiMedico
{
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/medicos")]
        public async Task<IActionResult> ObtemTodosMedicos() =>
            Ok(await _mediator.Send(new ObtemTodosMedicosQuery()));

        [HttpGet]
        [Route("api/medicos/{id}")]
        public async Task<IActionResult> ObtemMedicoPorId(Guid id) => 
            Ok(await _mediator.Send(new ObtemMedicoPorIdQuery { Id = id }));

        [HttpPost]
        [Route("api/medicos")]
        [ModelValidationAttribute]
        public async Task<IActionResult> InsereMedico(AdicionaMedicoInputModel medicoInputModel)
        {
            var result = await _mediator.Send(new AdicionaMedicoCommand { Medico = medicoInputModel } );
            return Created($"api/medicos/{result.Id}", result);
        }

        [HttpDelete]
        [Route("api/medicos/{id}")]
        public async Task<IActionResult> ExcluiMedico(Guid id)
        {
            await _mediator.Send(new ExcluiMedicoCommand { Id = id });
            return NoContent();
        }
    }
}
