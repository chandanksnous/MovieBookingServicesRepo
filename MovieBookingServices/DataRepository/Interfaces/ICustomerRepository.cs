using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Data
{
    public interface ICustomerRepository
    {
        ServiceResponse<List<MovieDTO>> GetMoviesBySerachCriteria (MovieSearchCriteriaFields searchCriteria);

        Task<ServiceResponse<bool>> BookMovie (CustomersTicketBookingHistory bookMovie);
    }
}
