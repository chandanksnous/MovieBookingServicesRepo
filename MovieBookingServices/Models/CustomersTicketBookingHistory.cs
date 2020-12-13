using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking.Models
{
    public class CustomersTicketBookingHistory
    {
        public int ID { get; set; }
        [Range(1,5)]
        public int BookedSeatsCount { get; set; }
        public string CustomerName { get; set; }
        public MovieVenueInfo MovieVenueInfo { get; set; }
        [ForeignKey("MovieVenueInfo")]
        public int MovieIDFK { get; set; }
        public DateTime BookedDate { get; set; }

    }


    public class CustomersTicketBookingHistoryDTO
    {
       
        [Range(1,5)]
        public int BookedSeatsCount { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookedDate { get; set; }
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
}
