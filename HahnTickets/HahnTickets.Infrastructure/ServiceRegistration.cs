using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Infrastructure.Persistence;
using HahnTickets.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HahnTickets.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<HahnDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITicketRepository, TicketRepository>();
            return services;
        }
    }
}
