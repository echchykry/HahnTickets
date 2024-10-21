using HahnTickets.Application.Features.Tickets.Queries.GetAll;
using HahnTickets.Domain.Entities;
using Mapster;

namespace HahnTickets.Api.Mapping
{
    public class TicketMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Ticket, GetAllTicketsDto>()
                .Map(dest => dest.Status, src => src.Status.Label);
        }
    }
}
