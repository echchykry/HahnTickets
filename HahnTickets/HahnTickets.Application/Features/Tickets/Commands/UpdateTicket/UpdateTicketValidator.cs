using FluentValidation;

namespace HahnTickets.Application.Features.Tickets.Commands.UpdateTicket
{
    public class UpdateTicketValidator : AbstractValidator<UpdateTicketCommand>
    {
        public UpdateTicketValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => (int)x.StatusId).GreaterThan(0);
        }
    }
}
