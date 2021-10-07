using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.AdicionaMedico
{
    public class AdicionaMedicoCommand : IRequest<AdicionaMedicoResponse>
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public class AdicionaMedicoCommandHandler : IRequestHandler<AdicionaMedicoCommand, AdicionaMedicoResponse>
        {
            private readonly VerticalSliceContext _context;
            private readonly IMapper _mapper;

            public AdicionaMedicoCommandHandler(VerticalSliceContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AdicionaMedicoResponse> Handle(AdicionaMedicoCommand command,
                CancellationToken cancellationToken)
            {
                var medico = _mapper.Map<Medico>(command);
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                return _mapper.Map<AdicionaMedicoResponse>(medico);
            }
        }
    }

    public class AdicionaMedicoCommandProfile : Profile
    {
        public AdicionaMedicoCommandProfile()
        {
            CreateMap<AdicionaMedicoCommand, Medico>();
        }
    }

    public record AdicionaMedicoResponse(Guid Id,
                                          string Nome,
                                          string Email,
                                          DateTime DataCriacao)
    {
        public class AdicionaMedicoViewModelProfile : Profile
        {
            public AdicionaMedicoViewModelProfile()
            {
                CreateMap<Medico, AdicionaMedicoResponse>();
            }
        }
    }
}