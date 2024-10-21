using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Domain.Entities;
using HahnTickets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HahnTickets.Infrastructure.Repositories
{
    public class TicketRepository(HahnDbContext hahnDbContext) : ITicketRepository
    {
        private readonly HahnDbContext _hahnDbContext = hahnDbContext;
        public async Task AddTicketAsync(Ticket ticket)
        {
            _hahnDbContext.Tickets.Add(ticket);
            await _hahnDbContext.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _hahnDbContext.Entry(ticket).State = EntityState.Modified;
            await _hahnDbContext.SaveChangesAsync();
        }
        public async Task DeleteTicketAsync(int id)
        {
            var ticket = _hahnDbContext.Tickets.Single(t => t.Id == id);
            _hahnDbContext.Tickets.Remove(ticket);
            await _hahnDbContext.SaveChangesAsync();
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _hahnDbContext.Tickets.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _hahnDbContext.Tickets.AsNoTracking()
                .Include(x => x.Status).ToListAsync();
        }
    }
}
