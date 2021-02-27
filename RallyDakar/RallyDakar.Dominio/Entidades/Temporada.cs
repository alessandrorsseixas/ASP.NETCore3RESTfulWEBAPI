using System;
using System.Collections.Generic;

namespace RallyDakar.Dominio.Entidades
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        //Nullable em C# é representado por "?"
        public DateTime? DataFim { get; set; }

        public ICollection<Equipe> Equipes { get; set; }

        public ICollection<Telemetria> Telemetrias { get; set; }
    }
}
