using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBooking.Data;
using MovieBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController :ControllerBase
    {

        private readonly ICustomerRepository _customerRepo;
        public CustomerController (ICustomerRepository custRepository)
        {
            _customerRepo = custRepository;
        }

        [Route("GetMoviesInfo")]
        [Authorize(Roles = "Customer")]
        public ServiceResponse<List<MovieDTO>> GetMoviesBySerachCriteria(MovieSearchCriteriaFields searchCriteria) =>

            this._customerRepo.GetMoviesBySerachCriteria(searchCriteria);



        [Route("BookMovieAsync")]
        [Authorize(Roles = "Customer")]
        public async Task<ServiceResponse<bool>> BookMovieAsync(CustomersTicketBookingHistoryDTO movieobj)
        {
            CustomersTicketBookingHistory obj = new CustomersTicketBookingHistory
            {
                CustomerName = this.HttpContext.User.Identity.Name,
                BookedDate = DateTime.Now.Date,
                BookedSeatsCount = movieobj.BookedSeatsCount,
                MovieIDFK = (((this._customerRepo.GetMoviesBySerachCriteria(new MovieSearchCriteriaFields { City = movieobj.City,MovieLanguage = movieobj.MovieLanguage,MovieName = movieobj.MovieName,MultiplexName = movieobj.MultiplexName,MovieType = movieobj.MovieType })) as ServiceResponse<List<MovieDTO>>).Data as List<MovieDTO>).FirstOrDefault().ID

            };

            return await this._customerRepo.BookMovie(obj);
        }

    }
}
