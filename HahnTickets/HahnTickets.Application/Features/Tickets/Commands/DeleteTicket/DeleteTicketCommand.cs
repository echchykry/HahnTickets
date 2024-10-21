using ErrorOr;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Commands.DeleteTicket
{
    public record DeleteTicketCommand(int TicketId) : IRequest<ErrorOr<Success>>;
}
