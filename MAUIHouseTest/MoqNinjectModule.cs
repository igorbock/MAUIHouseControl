using Ninject.Modules;
using Ninject.Planning.Bindings;

namespace MAUIHouseTest
{
    public class MoqNinjectModule : NinjectModule
    {
        private readonly ICollection<IBinding> _bindings;

        public MoqNinjectModule(ICollection<IBinding> bindings)
        {
            _bindings = bindings;
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public ICollection<IBinding> Bindings => _bindings;
    }
}
