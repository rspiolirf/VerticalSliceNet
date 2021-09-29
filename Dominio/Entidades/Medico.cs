using System;

namespace VerticalSlice.Dominio.Entidades
{
    public class Medico
    {
        public Medico()
        {}

        public Medico(string nome, string email) : this(Guid.NewGuid(), nome, email ) {}

        public Medico(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataCriacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}