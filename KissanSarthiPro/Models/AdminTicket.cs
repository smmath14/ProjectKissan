using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthiPro.Models
{
    public class AdminTicket
    {
        public string AdminName { get; set; }
        public string TicketId { get; set; }
        public DateTime DateofCreated { get; set; }
        public string Message { get; set; }
    }
}
