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
            Bind<SQLiteDbContext>().ToSelf()
                .InSingletonScope()
                .OnActivation(ctx => ctx.ChangeTracker.AutoDetectChangesEnabled = false);

            Bind<IRepository<Produto>>().To<ProdutoRepository>().InThreadScope();
            Bind<IRepository<Marca>>().To<MarcaRepository>().InThreadScope();
            Bind<IRepository<Operacao>>().To<OperacaoRepository>().InThreadScope();
        }
    }
}
