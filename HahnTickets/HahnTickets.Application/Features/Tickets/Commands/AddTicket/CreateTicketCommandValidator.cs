using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Application.Features.Tickets.Commands.AddTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => (int)x.StatusId).GreaterThan(0);
        }
    }
}
