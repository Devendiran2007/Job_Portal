using Microsoft.EntityFrameworkCore;


namespace Job_Portal.Backend.Models;

public class User {

    public int Id {get; set;}

    public string FullName {get; set;} = string.Empty();

    public string Email {get; set;} = string.Empty();

    public string PasswordHash {get; set;} = string.Empty();

    public string Role {get; set;} = string.Empty();

    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

    public ICollection<Job> PostedJobs {get ; set;} = new List<Job>();

    public ICollection<Application> Applications {get; set;} = new List<Application>();

}

public enum Role {
    Recruiter,
    Candidate
}
