using Microsoft.Extensions.DependencyInjection;
using Ninject.Infrastructure;
using Ninject.Modules;

namespace WarehouseLogic.Extensions
{
    public static class NinjectExtensions
    {
        public static IServiceCollection AddNinjectBindings(this IServiceCollection services, NinjectModule module)
        {
            foreach (var binding in module.Bindings)
            {
                var scope = binding.ScopeCallback;
                if (scope == StandardScopeCallbacks.Transient)
                    services.AddTransient(binding.Service);
                else if (scope == StandardScopeCallbacks.Singleton)
                    services.AddSingleton(binding.Service);
                else if (scope == StandardScopeCallbacks.Thread)
                    services.AddScoped(binding.Service);
            }

            return services;
        }
    }
}
