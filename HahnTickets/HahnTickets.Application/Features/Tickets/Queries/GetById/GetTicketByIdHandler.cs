using ErrorOr;
using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Shared.Errors;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Application.Features.Tickets.Queries.GetById
{
    public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, ErrorOr<GetTicketByIdDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByIdHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<ErrorOr<GetTicketByIdDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id);
            if (ticket is null)
                return TicketErrors.NotFound;

            return ticket.Adapt<GetTicketByIdDto>();
        }
    }
}
