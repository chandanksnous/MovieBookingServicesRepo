using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking.Models
{
    public class MovieVenueInfo
    {
        public int ID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieLanguage { get; set; }
        [Required]
        public string MovieType { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string MultiplexName { get; set; }
    

    }

    public class MovieDTO :MovieVenueInfo
    {
        public int AvilableSeatCount { get; set; }
    }
}
