using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Application.Features.Tickets.Commands.AddTicket
{
    public record CreateTicketDto(
        int Id,
        string Description,
        string Status,
        DateTime Date);
}
