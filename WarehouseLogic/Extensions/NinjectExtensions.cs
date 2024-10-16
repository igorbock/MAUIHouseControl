using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Modules;
using System;

namespace WarehouseLogic.Extensions
{
    public static class NinjectExtensions
    {
        public static IServiceCollection AddNinjectBindings(this IServiceCollection services, NinjectModule module)
        {
            if (module.Kernel == null)
                module.OnLoad(new StandardKernel());

            foreach (var binding in module.Bindings)
            {
                var service = binding.Service;
                var implementType = binding.ProviderCallback?.Target?.GetType();

                if (implementType == null)
                    throw new NotImplementedException($"Tipo de implementação não encontrado para o serviço {service.Name}");

                var scope = binding.ScopeCallback;
                if (scope == StandardScopeCallbacks.Transient)
                    services.AddTransient(service, implementType);
                else if (scope == StandardScopeCallbacks.Singleton)
                    services.AddSingleton(service, implementType);
                else if (scope == StandardScopeCallbacks.Thread)
                    services.AddScoped(service, implementType);
            }

            return services;
        }
    }
}
