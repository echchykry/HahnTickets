using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public Status Status { get; set; } = null!; // we can use just a boolean field
        public byte StatusId { get; set; }
    }
}
