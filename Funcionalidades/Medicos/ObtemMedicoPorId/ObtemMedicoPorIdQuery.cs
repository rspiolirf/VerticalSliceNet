using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemMedicoPorId
{
    public class ObtemMedicoPorIdQuery : IRequest<ObtemMedicoPorIdViewModel>
    {
        public Guid Id { get; set; }
        
        public class ObtemMedicoPorIdQueryHandler : IRequestHandler<ObtemMedicoPorIdQuery, ObtemMedicoPorIdViewModel>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public ObtemMedicoPorIdQueryHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ObtemMedicoPorIdViewModel> Handle(ObtemMedicoPorIdQuery query, CancellationToken cancellationToken)
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == query.Id);
                return _mapper.Map<ObtemMedicoPorIdViewModel>(medico);
            }
        }
    }

    public record ObtemMedicoPorIdViewModel(Guid Id, string Nome)
    {
        public class ObtemMedicoPorIdViewModelProfile : Profile
        {
            public ObtemMedicoPorIdViewModelProfile()
            {
                CreateMap<Medico, ObtemMedicoPorIdViewModel>();
            }
        }
    }
}