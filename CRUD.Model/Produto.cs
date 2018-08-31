using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Model
{
    [Table("PRODUTO")]
    public class Produto
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("DESCRICAO")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Column("VALOR")]
        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Valor { get; set; }

        public int CategoriaId { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}
