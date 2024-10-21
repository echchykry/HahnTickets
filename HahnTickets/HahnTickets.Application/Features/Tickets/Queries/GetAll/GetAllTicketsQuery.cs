using MediatR;
using ErrorOr;
using HahnTickets.Application.Enums;
using HahnTickets.Shared.Pagination;

namespace HahnTickets.Application.Features.Tickets.Queries.GetAll
{
    public record GetAllTicketsQuery(OrderBy OrderBy, int pageIndex, int pageSize) : IRequest<PaginatedList<GetAllTicketsDto>>;

}
