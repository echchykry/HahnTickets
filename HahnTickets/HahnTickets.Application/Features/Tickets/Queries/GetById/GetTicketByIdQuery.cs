using ErrorOr;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Queries.GetById
{
    public class GetTicketByIdQuery : IRequest<ErrorOr<GetTicketByIdDto>>
    {
        public int Id { get; set; }
    }
}
