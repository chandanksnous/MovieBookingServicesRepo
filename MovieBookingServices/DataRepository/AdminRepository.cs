using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Data
{
    public class AdminRepository :IAdminRepository
    {

        private readonly DataContext _context;

        public AdminRepository (DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<bool>> AddMovie (MovieVenueInfo movieVenueInfo)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            await this._context.MovieVenueInfo.AddAsync(movieVenueInfo);
            await this._context.SaveChangesAsync();
            response.Message = "Movie Added Succesfully";

            return response;
        }
    }
}
