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

        public void Adicionar(Piloto piloto)
        {
            _rallyDbContext.Pilotos.Add(piloto);

        }

        public IEnumerable<Piloto> ObterTodos()
        {

           return _rallyDbContext.Pilotos.ToList();

        }

        public Piloto Obter(int pilotoId)
        {

            return _rallyDbContext.Pilotos.FirstOrDefault(x=>x.Id == pilotoId);

        }

        public bool Exite(int pilotoId)
        {

            return _rallyDbContext.Pilotos.Any(x => x.Id == pilotoId);

        }

        public IEnumerable<Piloto> ObterTodos(string nome)
        {

            return _rallyDbContext.Pilotos
                .Where(x=>x.Nome.Contains(nome))
                .ToList();

        }
    }
}
