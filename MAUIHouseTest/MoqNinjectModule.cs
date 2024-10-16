using Ninject.MockingKernel.Moq;
using WarehouseLib.Interfaces;
using WarehouseLib.Models;
using WarehouseLogic.Repositories;

namespace MAUIHouseTest
{
    public class MoqNinjectModule : MoqModule
    {
        public override void Load()
        {
            Bind<IRepository<Produto>>().To<ProdutoRepository>().InSingletonScope();
            Bind<IRepository<Marca>>().To<MarcaRepository>().InThreadScope();
        }
    }
}
