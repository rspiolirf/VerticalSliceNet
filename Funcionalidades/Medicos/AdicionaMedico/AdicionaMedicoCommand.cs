using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.AdicionaMedico
{
    public class AdicionaMedicoCommand : IRequest<AdicionaMedicoViewModel>
    {
        private readonly AdicionaMedicoInputModel _medico;

        public AdicionaMedicoCommand(AdicionaMedicoInputModel medico)
        {
            _medico = medico;
        }

        public class AdicionaMedicoCommandHandler : IRequestHandler<AdicionaMedicoCommand, AdicionaMedicoViewModel>
        {
            private readonly VerticalSliceContext _context;

            public AdicionaMedicoCommandHandler(VerticalSliceContext context)
            {
                _context = context;
            }

            public async Task<AdicionaMedicoViewModel> Handle(AdicionaMedicoCommand command,
                CancellationToken cancellationToken)
            {
                var medico = new Medico(command._medico.Nome, command._medico.Email);
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                return new AdicionaMedicoViewModel(medico.Id,
                                                   medico.Nome,
                                                   medico.Email,
                                                   medico.DataCriacao);
            }
        }
    }

    public record AdicionaMedicoInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }

    public record AdicionaMedicoViewModel(Guid Id,
                                          string Nome,
                                          string Email,
                                          DateTime DataCriacao);
}