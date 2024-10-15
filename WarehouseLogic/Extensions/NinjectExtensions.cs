using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WarehouseLogic.Extensions
{
    public static class NinjectExtensions
    {
        public static IServiceCollection AddNinjectBindings<TypeT>(this IServiceCollection services, IKernel kernel)
        {
            foreach (var bind in kernel.GetBindings(typeof(TypeT)))
            {
                var lifetime = string.Empty;
                var scope = bind.ScopeCallback;
                if (scope == null)
                    lifetime = "Transient";
                else
                {
                    switch (scope.Method.Name)
                    {
                        case "GetSingletonScope":
                            lifetime = "Singleton";
                            break;
                        case "GetRequestScope":
                            lifetime = "Scoped";
                            break;
                        default:
                            lifetime = "Custom Scope";
                            break;
                    }
                }
            }
            return services;
        }

        public static IServiceCollection AddNinjectBindings(this IServiceCollection services, NinjectModule module)
        {
            //module.Load();
            foreach (var binding in module.Bindings)
            {
                var lifetime = string.Empty;
                var scope = binding.ScopeCallback;
                if (scope == null)
                    lifetime = "Transient";
                else
                {
                    switch (scope.Method.Name)
                    {
                        case "GetSingletonScope":
                            lifetime = "Singleton";
                            break;
                        case "GetRequestScope":
                            lifetime = "Scoped";
                            break;
                        default:
                            lifetime = "Custom Scope";
                            break;
                    }
                }
            }

            return services;
        }
    }
}
