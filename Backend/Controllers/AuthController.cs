using Job_Portal.DTOs;
using Microsoft.AspNetCore.Mvc;
using Job_Portal.DTOs;
using Job_Portal.Data;
using Job_Portal.Backend.Models;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(ApplicationDbContext context , IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("/register")]
    public  IActionResult Register([FromBody] RegisterDto registerdto){

        var existingUser =  _context.Users.FirstOrDefault(u => u.Email == registerdto.Email);

        if(existingUser != null) {
            return BadRequest("The Email is Already Registred");
        }

        var newUser = new User
        {
            FullName = registerdto.Name,
            Email = registerdto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerdto.Password),
            Role = registerdto.Role
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok(new
        {
            Message = "User Registered Successfully"
        });
    }

    [HttpPost("/login")]
    public  IActionResult Login([FromBody] LoginDto logindto) {

        var user =  _context.Users.FirstOrDefault(u => u.Email == logindto.Email);

        if(user == null || !BCrypt.Net.BCrypt.Verify(logindto.Password , user.PasswordHash)) {
            return BadRequest("Invalid Email or Password");
        }

        return Ok(new {
            Message = "Logined Successfully"
        });
    }
}


