using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.MockingKernel.Moq;
using WarehouseLogic.Extensions;

namespace MAUIHouseTest.DI
{
    public class NinjectExtensionsTest
    {
        private IServiceCollection _services;
        private MoqNinjectModule _moduleMock;
        private MoqMockingKernel _kernel;

        [TearDown]
        public void Dispose()
        {
            _kernel.Dispose();
            _moduleMock.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            _services = new ServiceCollection();
            _moduleMock = new MoqNinjectModule();

            _kernel = new MoqMockingKernel();
            _kernel.Load(_moduleMock);
        }

        [Test]
        public void AddNinjectBindingsTest()
        {
            _services.AddNinjectBindings(_moduleMock);

            Assert.IsTrue(_services.Any(a => a.Lifetime == ServiceLifetime.Singleton));
            Assert.That(_services.Count, Is.EqualTo(2));
            Assert.Pass();
        }
    }
}