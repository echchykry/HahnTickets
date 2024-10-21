using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTickets.Domain.Entities
{
    public class Status
    {
        public byte Id { get; set; }
        public string Label { get; set; } = null!;
    }
}
