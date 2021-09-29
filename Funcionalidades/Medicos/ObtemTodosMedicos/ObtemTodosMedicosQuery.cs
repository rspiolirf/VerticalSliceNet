using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemTodosMedicos
{
    public class ObtemTodosMedicosQuery : IRequest<IEnumerable<ObtemTodosMedicosViewModel>>
    {
        public class ObtemTodosMedicosQueryHandler : IRequestHandler<ObtemTodosMedicosQuery, IEnumerable<ObtemTodosMedicosViewModel>>
        {
            private readonly VerticalSliceContext _context;
            
            private readonly IMediator _mediator;

            public ObtemTodosMedicosQueryHandler(IMediator mediator, VerticalSliceContext context)
            {
                _mediator = mediator;
                _context = context;
            }

            public async Task<IEnumerable<ObtemTodosMedicosViewModel>> Handle(ObtemTodosMedicosQuery query,
                CancellationToken cancellationToken)
            {
                var medicos = await _context.Medicos.ToListAsync();
                return medicos.Select(medico => new ObtemTodosMedicosViewModel { Id = medico.Id, Nome = medico.Nome, Email = medico.Email })
                    .ToList<ObtemTodosMedicosViewModel>();
            }
        }
    }
}