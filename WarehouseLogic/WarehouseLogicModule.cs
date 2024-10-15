using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using WarehouseLib.Interfaces;
using WarehouseLib.Models;
using WarehouseLogic.Context;
using WarehouseLogic.Repositories;

namespace WarehouseLogic
{
    public class WarehouseLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContextOptions<SQLiteDbContext>>().ToSelf();
            Bind<SQLiteDbContext>().ToSelf().OnActivation(ctx => ctx.ChangeTracker.AutoDetectChangesEnabled = false);

            Bind<IRepository<Produto>>().To<ProdutoRepository>();
            Bind<IRepository<Marca>>().To<MarcaRepository>();
            Bind<IRepository<Operacao>>().To<OperacaoRepository>();
        }
    }
}
