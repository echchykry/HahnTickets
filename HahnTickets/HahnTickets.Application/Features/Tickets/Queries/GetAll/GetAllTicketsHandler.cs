using ErrorOr;
using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Shared.Pagination;
using Mapster;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Queries.GetAll
{
    public class GetAllTicketsHandler : IRequestHandler<GetAllTicketsQuery, PaginatedList<GetAllTicketsDto>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetAllTicketsHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<PaginatedList<GetAllTicketsDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetTicketsAsync();

            var ticketsDto = tickets.Adapt<List<GetAllTicketsDto>>();

            var result = PaginatedList<GetAllTicketsDto>.Create(ticketsDto, 
                request.pageIndex, request.pageSize);

            return result;

        }
    }
}
