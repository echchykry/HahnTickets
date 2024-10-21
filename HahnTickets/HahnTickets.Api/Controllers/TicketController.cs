using ErrorOr;
using HahnTickets.Application.Enums;
using HahnTickets.Application.Features.Tickets.Commands.AddTicket;
using HahnTickets.Application.Features.Tickets.Commands.DeleteTicket;
using HahnTickets.Application.Features.Tickets.Commands.UpdateTicket;
using HahnTickets.Application.Features.Tickets.Queries.GetAll;
using HahnTickets.Application.Features.Tickets.Queries.GetById;
using HahnTickets.Shared.Pagination;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HahnTickets.Api.Controllers
{
    [Route("[controller]")]
    public class TicketController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TicketController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("addTicket")]
        public async Task<IActionResult> AddTicketAsync(CreateTicketCommand request)
        {
            ErrorOr<CreateTicketDto> result = await _mediator.Send(request);

            return result.Match(
                result => Ok(result),
                errors => GlobalProblems(errors));
        }

        [HttpGet("GetAll{orderBy:int}")]
        public async Task<PaginatedList<GetAllTicketsDto>> GetAllTickets(OrderBy orderBy, int pageIndex, int pageSize)
        {
            var query = new GetAllTicketsQuery(orderBy, pageIndex, pageSize);
            var tickets = await _mediator.Send(query);
            return tickets;
        }

        [HttpGet("GetById{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetTicketByIdQuery() { Id = id };
            var ticket = await _mediator.Send(query);
            return ticket.Match(r => Ok(r),
                errors => GlobalProblems(errors));
        }

        [HttpDelete("{ticketId:int}")]
        public async Task<IActionResult> DeleteById(int ticketId)
        {
            DeleteTicketCommand command = new(ticketId);
            var result = await _mediator.Send(command);

            return result.Match(
                _ => NoContent(),
                errors => GlobalProblems(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTicketCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                _ => NoContent(),
                errors => GlobalProblems(errors));
        }
    }
}
