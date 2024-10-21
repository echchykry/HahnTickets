using ErrorOr;
using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Shared.Errors;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, ErrorOr<Success>>
    {
        private readonly ITicketRepository _ticketRepository;

        public DeleteTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<ErrorOr<Success>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.TicketId);
            if (ticket == null)
                return TicketErrors.NotFound;

            await _ticketRepository.DeleteTicketAsync(request.TicketId);
            return Result.Success;
        }
    }
}
