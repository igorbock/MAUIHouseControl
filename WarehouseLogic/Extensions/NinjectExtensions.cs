using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Infrastructure;
using Ninject.Modules;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;

namespace WarehouseLogic.Extensions
{
    public static class NinjectExtensions
    {
        public static void AddNinjectBindings(this IServiceCollection services, NinjectModule[] modules)
        {
            IKernel _kernel = new StandardKernel();
            var bindingCollection = new List<IBinding>();

            foreach (var module in modules)
            {
                module.OnLoad(_kernel);
                bindingCollection.AddRange(module.Bindings);
            }

            foreach (var binding in bindingCollection)
            {
                var service = binding.Service;
                Func<IServiceProvider, object> implementType = a => _kernel.GetService(service);

                if (implementType == null)
                    throw new NotImplementedException($"Tipo de implementação não encontrado para o serviço {service.Name}");

                var serviceName = _kernel.GetService(service)?.GetType().Name ?? implementType.Method.Name;
                var scope = binding.ScopeCallback;
                if (scope == StandardScopeCallbacks.Transient)
                    services.AddTransient(service, implementType);
                else if (scope == StandardScopeCallbacks.Singleton)
                    services.AddSingleton(service, implementType);
                else if (scope == StandardScopeCallbacks.Thread)
                    services.AddScoped(service, implementType);
            }
        }
    }
}
