using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseLib.Interfaces;

namespace WarehouseLib.Models
{
    [Table("OPERACOES", Schema = "dbo")]
    public class Operacao : IEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("VALOR")]
        public decimal Valor { get; set; }

        [NotMapped]
        public bool? IsEntrada { get; set; }

        [ForeignKey(nameof(Produto))]
        [Column("ID_PRODUTO")]
        public int IdProduto { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
    }
}
