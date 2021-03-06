using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VerticalSlice.Dominio.Excecoes;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ExcluiMedico
{
    public class ExcluiMedicoCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class ExcluiMedicoCommandHandler : IRequestHandler<ExcluiMedicoCommand, Guid>
        {
            private readonly VerticalSliceContext _context;

            public ExcluiMedicoCommandHandler(VerticalSliceContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(ExcluiMedicoCommand command, CancellationToken cancellationToken)
            {
                var medico = await _context.Medicos.FindAsync(command.Id);
                if (medico is null)
                    throw new MedicoInexistenteException($"Não existe o médico com o código {command.Id}.");
                
                _context.Remove(medico);
                await _context.SaveChangesAsync();
                
                return command.Id;
            }
        }
    }
}