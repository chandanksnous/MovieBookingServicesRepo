using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking.Models
{
    public class MovieSearchCriteriaFields
    {
        public string MovieName { get; set; }
        public string MovieType { get; set; }
        public string MovieLanguage { get; set; }
        public string City { get; set; }
        public string MultiplexName { get; set; }
    }
}
