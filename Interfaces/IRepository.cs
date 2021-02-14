using CadastroDeSeries.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeSeries.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntidadeBase
    {
        List<TEntity> Lista();
        TEntity RetornarPorId(int id);
        void Insere(TEntity entity);
        void Excluir(int id);
        void Atualizar(int id, TEntity entity);
        int Proximo();


    }
}
