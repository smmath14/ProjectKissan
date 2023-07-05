using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthiPro.Models
{
    public class NewUser
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your UserName")]
        [Display(Name = "Username : ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Your ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone No")]
        public string PhoneNo { get; set; }
    }

}
