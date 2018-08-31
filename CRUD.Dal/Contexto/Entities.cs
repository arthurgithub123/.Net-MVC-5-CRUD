using CRUD.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Dal.Contexto
{
    public class Entities : DbContext
    {
        public Entities() : base("conexaoDB")
        {

        }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Produto> Produto { get; set; }
    }
}
