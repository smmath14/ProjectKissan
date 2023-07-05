using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissanSarthi.Models
{
    public class Filter
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Area_of_land { get; set; }
        public string Type_of_Crops { get; set; }
        public string Categories_of_Crops { get; set; }

    }
}
