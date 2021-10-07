using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ConsultaMedicos
{
    public class ConsultaMedicosQuery : IRequest<IEnumerable<ConsultaMedicosResponse>>
    {
        public class ConsultaMedicosQueryHandler : IRequestHandler<ConsultaMedicosQuery, IEnumerable<ConsultaMedicosResponse>>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public ConsultaMedicosQueryHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ConsultaMedicosResponse>> Handle(ConsultaMedicosQuery query,
                CancellationToken cancellationToken)
            {
                var medicos = await _context.Medicos.ToListAsync();
                return _mapper.Map<List<Medico>, List<ConsultaMedicosResponse>>(medicos);
            }
        }
    }

    public record ConsultaMedicosResponse(Guid Id, string Nome, string Email)
    {
        public class ConsultaMedicosViewModelProfile : Profile
        {
            public ConsultaMedicosViewModelProfile()
            {
                CreateMap<Medico, ConsultaMedicosResponse>();
            }
        }
    }
}