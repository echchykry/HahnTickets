using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Application.Features.Tickets.Queries.GetById
{
    public record GetTicketByIdDto(
        int Id,
        string Desription,
        DateTime Date,
        byte StatusId);
}
