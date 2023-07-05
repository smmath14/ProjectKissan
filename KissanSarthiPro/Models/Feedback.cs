using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthiPro.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofCreated { get; set; }
        public string Message { get; set; }
    }
}
