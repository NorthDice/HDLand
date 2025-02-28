﻿using HDLand.Application.Services;
using HDLand.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HDLand.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.Username, request.Email, request.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var token = await _userService.Login(request.Email, request.Password);

                Response.Cookies.Append("HDLand", token);
            }
            return Ok();
        }
    }
}
