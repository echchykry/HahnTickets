using HahnTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HahnTickets.Infrastructure.Persistence
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
