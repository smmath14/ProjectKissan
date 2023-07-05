using KissanSarthiPro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthi.Models
{
    public class UserInput
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string City { get; set; }
        public int Pincode { get; set; }
        [Required(ErrorMessage = "Please Enter Area_of_land")]
        public int Area_of_land { get; set; }
        [Required(ErrorMessage = "Please Enter Type_of_Crops")]
        public string Type_of_Crops { get; set; }
        [Required(ErrorMessage = "Please Enter Categrories_of_Crops")]
        public string Categories_of_Crops { get; set; }
        public string Weather { get; set; }
        public string SoilType { get; set; }
        public string Temperature { get; set; }
        public string Pesticide { get; set; }
        public string Water { get; set; }
        public string Seeds { get; set; }
        public string  Cost { get; set; }
    }
    public class Agriindex
    {
        public Filter req { get; set; }
        public UserInput AgriShows { get; set; }
        public List<UserInput> AgriShow { get; set; }
        public Country myc { get; set; }
        public State mycs { get; set; }
        public City mycc { get; set; }

    }
}
