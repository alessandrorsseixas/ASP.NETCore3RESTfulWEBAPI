using System.Collections.Generic;

namespace RallyDakar.Dominio.Entidades
{
    public class Equipe
    {
        public int Id { get; set; }
        public string CodigoIdentificador { get; set; }
        public string Nome { get; set; }

        // Atributo para identificar o relacionamento no banco de dados para o entity framework(EF)
        public int TemporadaId { get; set; }

        // Ao utiliar Virtual o EF o entity framework em tempo de execução possibilita carregar os dados da entitidade.
        public virtual Temporada Temporada { get; set;}

        // Uma equipe possui um ou mais pilotos
        public ICollection<Piloto> Pilotos { get; set; }
    }
}
