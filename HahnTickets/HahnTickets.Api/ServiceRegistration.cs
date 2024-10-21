using Mapster;
using MapsterMapper;
using System.Reflection;

namespace HahnTickets.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
