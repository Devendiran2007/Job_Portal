using Microsoft.EntityFrameworkCore;
using Job_Portal.Backend.Models;

namespace Job_Portal.Data;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    
    public DbSet<User> Users {get; set;}
    public DbSet<Application> Applications {get; set;}
    public DbSet<Job> Jobs {get; set;}

}