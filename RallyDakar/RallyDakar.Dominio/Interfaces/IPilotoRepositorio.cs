using RallyDakar.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RallyDakar.Dominio.Interfaces
{
    public interface IPilotoRepositorio
    {
        void Adicionar(Piloto piloto);

        void Atualizar(Piloto piloto);
        void Deletar(Piloto piloto);

        IEnumerable<Piloto> ObterTodos();

        IEnumerable<Piloto> ObterTodos(string nome);

        Piloto Obter(int pilotoId);

        bool Existe(int pilotoId);




    }
}
