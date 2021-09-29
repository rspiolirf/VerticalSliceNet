using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.AdicionaMedico
{
    public class AdicionaMedicoCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public class AdicionaMedicoCommandHandler : IRequestHandler<AdicionaMedicoCommand, Guid>
        {
            private readonly VerticalSliceContext _context;

            private readonly IMediator _mediator;

            public AdicionaMedicoCommandHandler(IMediator mediator, VerticalSliceContext context)
            {
                _mediator = mediator;
                _context = context;
            }

            public async Task<Guid> Handle(AdicionaMedicoCommand command, CancellationToken cancellationToken)
            {
                var medico = new Medico(command.Nome, command.Email);
                await _context.AddAsync(medico);
                await _context.SaveChangesAsync();

                return medico.Id;
            }
        }
    }
}