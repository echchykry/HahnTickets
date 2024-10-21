using ErrorOr;
using HahnTickets.Application.Contracts.Persistence;
using MediatR;
using FluentValidation.Results;
using HahnTickets.Domain.Entities;
using Mapster;
using HahnTickets.Shared.Errors;

namespace HahnTickets.Application.Features.Tickets.Commands.AddTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<CreateTicketDto>>
    {
        private readonly ITicketRepository _ticketRepository;
        public CreateTicketCommandHandler(ITicketRepository ticketRepository)
        {
                _ticketRepository = ticketRepository;
        }
        public async Task<ErrorOr<CreateTicketDto>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            CreateTicketCommandValidator validator = new();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                return TicketErrors.CannotSave;

            var ticket = new Ticket()
            {
                Description = request.Description,
                StatusId = request.StatusId,
                Date = DateTime.UtcNow,
            };

            await _ticketRepository.AddTicketAsync(ticket);
            var ticketDto = ticket.Adapt<CreateTicketDto>();
            return ticketDto;
        }
    }
}
