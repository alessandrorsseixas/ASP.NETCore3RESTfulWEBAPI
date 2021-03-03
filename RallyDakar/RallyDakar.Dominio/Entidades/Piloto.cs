using System.Collections.Generic;

namespace RallyDakar.Dominio.Entidades
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EquipeID { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
