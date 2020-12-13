using Moq;
using MovieBooking.Controllers;
using MovieBooking.Data;
using MovieBooking.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MovieBookingServices.Tests
{
    public class AdminRepositoryTest
    {
        //Arrange
        //Act
        //Assert

        [Fact]
        public void TestIsMovieAdded()
        {
            Mock<IAdminRepository> mock = new Mock<IAdminRepository>();
            mock.Setup(p => p.AddMovie(new MovieBooking.Models.MovieVenueInfo { MovieLanguage = "Hindi",MovieName = "Movie1",City = "Bengalore",MultiplexName = "Orion",MovieType = "Action" })).Returns<Task<ServiceResponse<bool>>>(x => x);
            AdminController home = new AdminController(mock.Object);
            Task<ServiceResponse<bool>> result = home.AddMovieAsync(new MovieVenueInfo
            {
                MovieLanguage = "Hindi",
                MovieName = "Movie1",
                City = "Bengalore",
                MultiplexName = "Orion",
                MovieType = "Action"
            });

            result.Wait();

            Assert.True(result.Result.Success);
        }
    }
}
