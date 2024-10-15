using Microsoft.Extensions.DependencyInjection;
using Moq;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using WarehouseLogic;
using WarehouseLogic.Extensions;
using WarehouseLogic.Repositories;

namespace MAUIHouseTest
{
    public class Tests
    {
        private IKernel _kernel;
        private IServiceCollection _services;
        private Mock<MoqNinjectModule> _moduleMock;
        private ICollection<IBinding> _bindings;

        [SetUp]
        public void Setup()
        {
            _bindings = new List<IBinding>();

            var binding1 = new Mock<IBinding>();
            var binding2 = new Mock<IBinding>();

            binding1.Setup(a => a.Service).Returns(typeof(ProdutoRepository));
            binding2.Setup(a => a.Service).Returns(typeof(MarcaRepository));

            _bindings.Add(binding1.Object);
            _bindings.Add(binding2.Object);

            _moduleMock = new Mock<MoqNinjectModule>(_bindings);
        }

        [Test]
        public void Test1()
        {
            _moduleMock.Setup(m => m.Bindings).Returns(_bindings);
            _services.AddNinjectBindings(_moduleMock.Object);

            

            Assert.Pass();
        }

        [TearDown]
        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}