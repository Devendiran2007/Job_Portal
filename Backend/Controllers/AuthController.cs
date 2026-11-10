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
    public async IActionResult Register([FromBody] RegisterDto registerdto){

        var existingUser = await _context.Users.FirstOrDefault(u => u.Email == registerdto.Email);

        if(existingUser != null) {
            return BadRequest("The Email is Already Registred");
        }

        var newUser = new User
        {
            FullName = registerdto.Name,
            Email = registerdto.Email,
            PasswordHash = registerdto.Password,
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
    public async IActionResult Login([FromBody] LoginDto logindto) {

        var user = await _context.Users.FirstOrDefault(u => u.Email == logindto.Email && u.PasswordHash == logindto.Password);

        if(user == null) {
            return BadRequest("The Email is not registred");
        }

        return Ok(new {
            Message = "Logined Successfully"
        });
    }
}


