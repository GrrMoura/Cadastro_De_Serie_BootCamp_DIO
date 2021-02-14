using CadastroDeSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeSeries.Classes
{
    class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entity)
        {
            listaSerie[id] = entity;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entity)
        {
            listaSerie.Add(entity);
        }

        public List<Serie> Lista()
        {
            return listaSerie; ;
        }

        public int Proximo()
        {
           return listaSerie.Count();
        }

        public Serie RetornarPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
