using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Dominio.Excecoes;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ConsultaMedicoPorId
{
    public class ConsultaMedicoPorIdQuery : IRequest<ConsultaMedicoPorIdResponse>
    {
        public Guid Id { get; set; }
            
        public class ConsultaMedicoPorIdQueryHandler : IRequestHandler<ConsultaMedicoPorIdQuery, ConsultaMedicoPorIdResponse>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public ConsultaMedicoPorIdQueryHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ConsultaMedicoPorIdResponse> Handle(ConsultaMedicoPorIdQuery query,
                CancellationToken cancellationToken)
            {
                var medico = await _context.Medicos.FindAsync(query.Id);
                if (medico is null)
                    throw new MedicoInexistenteException($"Não existe o médico com o código {query.Id}.");
                    
                return _mapper.Map<ConsultaMedicoPorIdResponse>(medico);
            }
        }
    }

    public record ConsultaMedicoPorIdResponse(Guid Id, string Nome)
    {
        public class ConsultaMedicoPorIdViewModelProfile : Profile
        {
            public ConsultaMedicoPorIdViewModelProfile()
            {
                CreateMap<Medico, ConsultaMedicoPorIdResponse>();
            }
        }
    }
}