using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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

            public ObtemTodosMedicosQueryHandler(VerticalSliceContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ObtemTodosMedicosViewModel>> Handle(ObtemTodosMedicosQuery query,
                CancellationToken cancellationToken)
            {
                var medicos = await _context.Medicos.ToListAsync();
                return medicos.Select(medico => new ObtemTodosMedicosViewModel(medico.Id,
                                                                               medico.Nome,
                                                                               medico.Email))
                    .ToList<ObtemTodosMedicosViewModel>();
            }
        }
    }

    public record ObtemTodosMedicosViewModel(Guid Id,
                                             string Nome,
                                             string Email)
    {
        public class ObtemTodosMedicosViewModelProfile : Profile
        {
            
        }
    }
}