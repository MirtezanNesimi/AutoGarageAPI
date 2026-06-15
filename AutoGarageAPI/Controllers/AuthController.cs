using AutoGarageAPI.DTOs;
using AutoGarageAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoGarageAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private static List<User> users = new();

    [HttpPost("register")]
    public IActionResult Register(RegisterDto dto)
    {
        var user = new User
        {
            Id = users.Count + 1,
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "Customer"
        };

        users.Add(user);

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var user = users.FirstOrDefault(x => x.Email == dto.Email);

        if (user == null)
            return Unauthorized();

        bool validPassword =
            BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!validPassword)
            return Unauthorized();

        return Ok(new
        {
            Message = "Login successful",
            User = user.FullName
        });
    }
}