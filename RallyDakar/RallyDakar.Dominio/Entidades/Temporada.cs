using System;

namespace RallyDakar.Dominio.Entidades
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        //Nullable em C# é representado por "?"
        public DateTime? DataFim { get; set; }
    }
}
