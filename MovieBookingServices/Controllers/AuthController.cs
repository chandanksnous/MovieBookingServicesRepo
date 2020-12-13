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
    [Route("[controller]")]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController (IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register (UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { Username = request.Username,Role=request.Role },request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login (UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.Username,request.Password);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //https://dev.to/_patrickgod/authentication-with-json-web-tokens-in-net-core-3-1-29bd
        //https://www.youtube.com/watch?v=l6s7AvZx5j8

        //https://www.c-sharpcorner.com/members/akhil-mittal4/articles-2
    }
}
