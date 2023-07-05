using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthiPro.Models
{
    public class AdminLog
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNo { get; set; }
    }
}
