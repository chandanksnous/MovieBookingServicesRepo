using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Data;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AdminController :ControllerBase
    {

        private readonly IAdminRepository _adminRepo;
        public AdminController (IAdminRepository authRepository)
        {
            _adminRepo = authRepository;
        }

        [HttpPost]
        [Route("AddMovieAsync")]
        [Authorize(Roles = "Admin")]
        public async Task<ServiceResponse<bool>> AddMovieAsync (MovieVenueInfo movieVenueInfo) =>
             await this._adminRepo.AddMovie(movieVenueInfo);


    }
}
