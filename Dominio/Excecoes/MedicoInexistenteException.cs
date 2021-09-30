using System;

namespace VerticalSlice.Dominio.Excecoes
{
    public class MedicoInexistenteException : Exception
    {
        public MedicoInexistenteException() { }

        public MedicoInexistenteException(string message) : base(message) { }

        public MedicoInexistenteException(string message, System.Exception inner) : base(message, inner) { }
        
        protected MedicoInexistenteException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}