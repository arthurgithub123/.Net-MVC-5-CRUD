using CRUD.Dal.Contexto;
using CRUD.Dal.Repository;
using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dal
{
    public class ProdutoDal : Repository<Produto>
    {
        public ProdutoDal(Entities contexto) : base(contexto)
        {
        }
    }
}
