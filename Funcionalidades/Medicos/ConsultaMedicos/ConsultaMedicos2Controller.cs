using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VerticalSlice.Funcionalidades.Medicos.ConsultaMedicos;

namespace VerticalSlice.Funcionalidades.Medicos.ExcluiMedico
{
    [ApiController]
    public class ConsultaMedicos2Controller : Controller
    {
        private readonly IMediator _mediator;

        public ConsultaMedicos2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("consultamedicos")]
        public async Task<IActionResult> ConsultaMedicos2()
        {
            var medicos = await _mediator.Send(new ConsultaMedicosQuery());
            return View("/Funcionalidades/Medicos/ConsultaMedicos/ConsultaMedicos.cshtml", medicos);
        }
    }
}