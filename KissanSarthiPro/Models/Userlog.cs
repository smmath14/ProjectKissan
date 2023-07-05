using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthi.Models
{
    public class Userlog
    {
        public int UserId { get; set; }
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your UserName")]
        [Display(Name = "Username : ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        public string ConfirmPassword { get; set; }

        public string PhoneNo { get; set; }
    }
}
