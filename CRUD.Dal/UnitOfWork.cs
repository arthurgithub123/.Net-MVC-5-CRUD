using CRUD.Dal.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dal
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            _contexto = new Entities();
        }

        private Entities _contexto;

        private CategoriaDal _categoriaDal;

        public CategoriaDal CategoriaDal
        {
            get { return _categoriaDal ?? (_categoriaDal = new CategoriaDal(_contexto)); }
        }

        private ProdutoDal _produtoDal;

        public ProdutoDal ProdutoDal
        {
            get { return _produtoDal ?? (_produtoDal = new ProdutoDal(_contexto)); }
        }
    }
}
