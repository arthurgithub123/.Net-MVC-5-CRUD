using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dal.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterTodos();
        IQueryable<T> Obter(Func<T, bool> predicate);
        T Encontrar(params object[] key);
        void Atualizar(T obj);
        void Adicionar(T obj);
        void Excluir(Func<T, bool> predicate);
    }
}
