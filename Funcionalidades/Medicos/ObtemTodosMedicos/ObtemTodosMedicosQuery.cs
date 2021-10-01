using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemTodosMedicos
{
    public class ObtemTodosMedicosQuery : IRequest<IEnumerable<ObtemTodosMedicosViewModel>>
    {
        public class ObtemTodosMedicosQueryHandler : IRequestHandler<ObtemTodosMedicosQuery, IEnumerable<ObtemTodosMedicosViewModel>>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public ObtemTodosMedicosQueryHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ObtemTodosMedicosViewModel>> Handle(ObtemTodosMedicosQuery query,
                CancellationToken cancellationToken)
            {
                var medicos = await _context.Medicos.ToListAsync();
                return _mapper.Map<List<Medico>, List<ObtemTodosMedicosViewModel>>(medicos);
            }
        }
    }

    public record ObtemTodosMedicosViewModel(Guid Id, string Nome, string Email)
    {
        public class ObtemTodosMedicosViewModelProfile : Profile
        {
            public ObtemTodosMedicosViewModelProfile()
            {
                CreateMap<Medico, ObtemTodosMedicosViewModel>();
            }
        }
    }
}