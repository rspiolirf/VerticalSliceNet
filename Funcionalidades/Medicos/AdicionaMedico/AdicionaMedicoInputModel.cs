using System.ComponentModel.DataAnnotations;

namespace VerticalSlice.Funcionalidades.Medicos.AdicionaMedico
{
    public class AdicionaMedicoInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}