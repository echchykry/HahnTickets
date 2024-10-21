using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Application.Features.Tickets.Queries.GetAll
{
    public record GetAllTicketsDto(
        int Id,
        string Description,
        DateTime Date,
        string Status);
}
