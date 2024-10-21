using ErrorOr;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Commands.UpdateTicket
{
    public record UpdateTicketCommand(int Id,
        string Description,
        byte StatusId) : IRequest<ErrorOr<Success>>;
}
