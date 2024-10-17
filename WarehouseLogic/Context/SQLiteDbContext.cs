using Microsoft.EntityFrameworkCore;
using WarehouseLib.Models;

namespace WarehouseLogic.Context
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() { }

        public SQLiteDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=mauidatabase.db");
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
    }
}
