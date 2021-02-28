using System;
using System.Collections.Generic;
using System.Xml.Serialization;

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

        public void AdicionarEquipe(Equipe equipe)
        {
            //Pré condição
            if (equipe != null)
            {

                if (!string.IsNullOrEmpty(equipe.Nome))
                {

                    Equipes.Add(equipe);
                }
            }

        }
    }
}
