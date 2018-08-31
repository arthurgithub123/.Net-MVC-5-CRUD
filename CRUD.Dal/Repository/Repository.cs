using CRUD.Dal.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(Entities contexto)
        {
            _contexto = contexto;
        }

        private Entities _contexto;

        public IQueryable<T> ObterTodos()
        {
            return _contexto.Set<T>();
        }

        public IQueryable<T> Obter(Func<T, bool> predicate)
        {
            return ObterTodos().Where(predicate).AsQueryable();
        }

        public T Encontrar(params object[] key)
        {
            return _contexto.Set<T>().Find(key);
        }

        public void Atualizar(T obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }

        public void Adicionar(T obj)
        {
            _contexto.Set<T>().Add(obj);
        }

        public void Excluir(Func<T, bool> predicate)
        {
            _contexto.Set<T>().Where(predicate).ToList().ForEach(del => _contexto.Set<T>().Remove(del));
        }
    }
}
