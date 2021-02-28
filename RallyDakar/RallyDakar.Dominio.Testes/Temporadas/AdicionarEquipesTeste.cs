using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyDakar.Dominio.Entidades;

namespace RallyDakar.Dominio.Testes.Temporadas
{
    [TestClass]
    public class AdicionarEquipesTeste
    {
        Temporada temporada;
        Equipe equipe1;
        Equipe equipe2;
        Equipe equipe3;


        // Metodo de inicialização do Teste
        [TestInitialize]
        public void Initialize()
        {
            temporada = new Temporada()
            {
                Id = 1,
                Nome = "Temporada2020"

            };

            equipe1 = new Equipe()
            {
                Id = 1,
                Nome = "EquipeTeste1"

            };
            equipe2 = new Equipe()
            {
                Id = 2,
                Nome = "EquipeTeste2"

            };
            equipe3 = new Equipe()
            {
                Id = 3,
                Nome = "EquipeTeste3"

            };

            temporada.AdicionarEquipe(equipe1);
            temporada.AdicionarEquipe(equipe2);
            temporada.AdicionarEquipe(equipe3);
        }
    }
}
