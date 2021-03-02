using RallyDakar.Dominio.DbContexto;
using RallyDakar.Dominio.Entidades;
using RallyDakar.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyDakar.Dominio.Repositorios
{
    public class PilotoRepositorio : IPilotoRepositorio
    {
        private readonly RallyDbContext _rallyDbContext;
        public PilotoRepositorio(RallyDbContext rallyDbContext)
        {
            _rallyDbContext = rallyDbContext;
        }

        public void AdicionarPiloto(Piloto piloto)
        {
            _rallyDbContext.Pilotos.Add(piloto);

        }

        public IEnumerable<Piloto> ObterTodosPilotos()
        {

           return _rallyDbContext.Pilotos.ToList();

        }

        public IEnumerable<Piloto> ObterTodosPilotos(string nome)
        {

            return _rallyDbContext.Pilotos
                .Where(x=>x.Nome.Contains(nome))
                .ToList();

        }
    }
}
