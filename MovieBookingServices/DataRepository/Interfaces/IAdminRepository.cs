using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBooking.Models;

namespace MovieBooking.Data
{
    public interface IAdminRepository
    {
        Task<ServiceResponse<bool>> AddMovie (MovieVenueInfo movieVenueInfo);
    }
}
