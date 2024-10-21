using ErrorOr;
using HahnTickets.Application.Contracts.Persistence;
using HahnTickets.Domain.Entities;
using HahnTickets.Shared.Errors;
using Mapster;
using MediatR;

namespace HahnTickets.Application.Features.Tickets.Commands.UpdateTicket
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand, ErrorOr<Success>>
    {
        private readonly ITicketRepository _ticketRepository;

        public UpdateTicketHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<ErrorOr<Success>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            UpdateTicketValidator validator = new();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                return TicketErrors.CannotSave;

            var ticket = await _ticketRepository.GetByIdAsync(request.Id);
            if (ticket == null)
                return TicketErrors.NotFound;

            ticket.Description = request.Description;
            ticket.Status = new Status() { Id = request.StatusId };

            await _ticketRepository.UpdateTicketAsync(ticket);
            return Result.Success;
        }
    }
}
