using HahnTickets.Domain.Entities;

namespace HahnTickets.Application.Contracts.Persistence
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<List<Ticket>> GetTicketsAsync();
        Task UpdateTicketAsync(Ticket ticket);
        Task AddTicketAsync(Ticket reservation);
        Task DeleteTicketAsync(int id);
    }
}
