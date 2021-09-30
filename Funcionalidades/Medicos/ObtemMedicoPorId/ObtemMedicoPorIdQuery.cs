using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSlice.Dominio.Entidades;
using VerticalSlice.Infraestrutura.Data;

namespace VerticalSlice.Funcionalidades.Medicos.ObtemMedicoPorId
{
    public class ObtemMedicoPorIdQuery : IRequest<Medico>
    {
        public Guid Id { get; set; }
        
        public class ObtemMedicoPorIdQueryHandler : IRequestHandler<ObtemMedicoPorIdQuery, Medico>
        {
            private readonly VerticalSliceContext _context;

            public ObtemMedicoPorIdQueryHandler(VerticalSliceContext context)
            {
                _context = context;
            }

            public async Task<Medico> Handle(ObtemMedicoPorIdQuery query, CancellationToken cancellationToken)
            {
                return await _context.Medicos.FirstOrDefaultAsync(m => m.Id == query.Id);
            }
        }
    }
}