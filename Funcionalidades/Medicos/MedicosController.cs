using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> InsereMedico(AdicionaMedicoInputModel medico)
        {
            if (!ModelState.IsValid) return BadRequest();

            var id = await _mediator.Send(new AdicionaMedicoCommand { Nome = medico.Nome, Email = medico.Email });
            var result = await _mediator.Send(new ObtemMedicoPorIdQuery { Id = id });
            return Created($"api/medicos/{id}", result);
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
