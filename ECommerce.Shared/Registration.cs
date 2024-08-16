using System.Reflection;
using ECommerce.Shared.AllShared.Concrete.Mapping;
using ECommerce.Shared.AllShared.Interfaces.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Shared
{
    public static class Registration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddScoped<IMapper, Mapper>();



            return services;
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
