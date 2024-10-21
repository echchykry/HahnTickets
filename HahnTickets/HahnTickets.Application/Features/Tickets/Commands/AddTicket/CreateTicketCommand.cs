using ErrorOr;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Commands.AddTicket
{
    public record CreateTicketCommand(
        string Description,
        byte StatusId) : IRequest<ErrorOr<CreateTicketDto>>;

}
