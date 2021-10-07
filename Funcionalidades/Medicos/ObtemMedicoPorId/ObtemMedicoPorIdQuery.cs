using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Dominio.Excecoes;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemMedicoPorId
{
    public class ObtemMedicoPorIdQuery : IRequest<ObtemMedicoPorIdResponse>
    {
        public Guid Id { get; set; }
            
        public class ObtemMedicoPorIdQueryHandler : IRequestHandler<ObtemMedicoPorIdQuery, ObtemMedicoPorIdResponse>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public ObtemMedicoPorIdQueryHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ObtemMedicoPorIdResponse> Handle(ObtemMedicoPorIdQuery query,
                CancellationToken cancellationToken)
            {
                var medico = await _context.Medicos.FindAsync(query.Id);
                if (medico is null)
                    throw new MedicoInexistenteException($"Não existe o médico com o código {query.Id}.");
                    
                return _mapper.Map<ObtemMedicoPorIdResponse>(medico);
            }
        }
    }

    public record ObtemMedicoPorIdResponse(Guid Id, string Nome)
    {
        public class ObtemMedicoPorIdViewModelProfile : Profile
        {
            public ObtemMedicoPorIdViewModelProfile()
            {
                CreateMap<Medico, ObtemMedicoPorIdResponse>();
            }
        }
    }
}