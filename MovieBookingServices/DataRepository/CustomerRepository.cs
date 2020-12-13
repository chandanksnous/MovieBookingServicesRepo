using MovieBooking.Data;
using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Data
{
    public class CustomerRepository :ICustomerRepository
    {

        private readonly DataContext _context;

        public CustomerRepository (DataContext context)
        {
            _context = context;
        }

        public ServiceResponse<List<MovieDTO>> GetMoviesBySerachCriteria (MovieSearchCriteriaFields searchCriteria)
        {
            IQueryable<MovieVenueInfo> result = this._context.MovieVenueInfo.AsQueryable();

            if(!string.IsNullOrEmpty(searchCriteria.MovieName))
                result = result.Where(x => x.MovieName.Contains(searchCriteria.MovieName));

            if(!string.IsNullOrEmpty(searchCriteria.MovieLanguage))
                result = result.Where(x => x.MovieLanguage.Contains(searchCriteria.MovieLanguage));

            if(!string.IsNullOrEmpty(searchCriteria.MovieType))
                result = result.Where(x => x.MovieType.Contains(searchCriteria.MovieType));

            if(!string.IsNullOrEmpty(searchCriteria.MultiplexName))
                result = result.Where(x => x.MultiplexName.Contains(searchCriteria.MultiplexName));

            if(!string.IsNullOrEmpty(searchCriteria.City))
                result = result.Where(x => x.City.Contains(searchCriteria.City));

            List<MovieDTO> moviesCol = new List<MovieDTO>();

            //TODO : We can make use of Automapper for object to object data copy..

            foreach(MovieVenueInfo item in result)
            {
                var bookedSeatsCount = this._context.CustomersTicketBookingHistory.Where(x => x.MovieIDFK == item.ID && x.BookedDate == DateTime.Now.Date).ToList().Select(x => x.BookedSeatsCount).Sum();

                moviesCol.Add(new MovieDTO { ID = item.ID,AvilableSeatCount = 100 - bookedSeatsCount,MovieName = item.MovieName,MovieLanguage = item.MovieLanguage,MultiplexName = item.MultiplexName,MovieType = item.MovieType,City = item.City });

            }

            ServiceResponse<List<MovieDTO>> movies = new ServiceResponse<List<MovieDTO>>();
            movies.Data = moviesCol;
            movies.Message = "List of Movies";

            return movies;
        }

        public async Task<ServiceResponse<bool>> BookMovie (CustomersTicketBookingHistory bookMovie)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var totalseatsBooked = this._context.CustomersTicketBookingHistory.Where(x => x.BookedDate == DateTime.Now.Date && x.MovieIDFK == bookMovie.MovieIDFK).Select(x => x.BookedSeatsCount).Sum();


            if(totalseatsBooked >= 100)
            {
                serviceResponse.Message = "No Seats Available";
                serviceResponse.Success = false;
            }

            if(totalseatsBooked + bookMovie.BookedSeatsCount > 100)
            {
                serviceResponse.Message = "Requested Number of Seats not Available";
                serviceResponse.Success = false;
            }

            if(totalseatsBooked < 100 && totalseatsBooked + bookMovie.BookedSeatsCount <= 100)
            {
                await this._context.CustomersTicketBookingHistory.AddAsync(bookMovie);
                await this._context.SaveChangesAsync();
                serviceResponse.Message = "Movie Booked";

            }

            return serviceResponse;
        }
    }
}
