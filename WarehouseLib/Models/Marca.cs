using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseLib.Interfaces;

namespace WarehouseLib.Models
{
    [Table("MARCAS", Schema = "dbo")]
    public class Marca : IEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("INATIVO")]
        public bool? Inativo { get; set; }
    }
}
