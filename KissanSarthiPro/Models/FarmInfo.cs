using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthiPro.Models
{
    public class FarmInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FarmName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int FarmSize { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date_of_Created { get; set; }
        public string Current_State { get; set; }
    }
}
