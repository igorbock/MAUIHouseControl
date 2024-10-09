using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseLib.Interfaces;

namespace WarehouseLib.Models
{
    [Table("PRODUTOS", Schema = "dbo")]
    public class Produto : IEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [StringLength(100)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("INATIVO")]
        public bool? Inativo { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [StringLength(10)]
        [Column("UNIDADE")]
        public string Unidade { get; set; }

        [NotMapped]
        public decimal ValorMedio { get; set; }

        [ForeignKey(nameof(Marca))]
        [Column("ID_MARCA")]
        public int IdMarca { get; set; }

        public virtual Marca Marca { get; set; }
    }
}
