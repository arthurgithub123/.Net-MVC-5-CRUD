using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    public class Categoria
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("VALOR")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
        
        public ICollection<Produto> Produto { get; set; }
    }
}
