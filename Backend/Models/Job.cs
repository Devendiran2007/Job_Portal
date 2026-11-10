using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Portal.Backend.Models;

public class Job {

    public int Id {get; set;}

    public string Title {get; set;} = string.Empty;

    public string Description {get; set;} = string.Empty;

    public string Location {get; set;} = string.Empty;

    public int Salary {get; set;}

    public string JobType {get; set;} = string.Empty;

    public bool IsActive {get; set;}

    //----Foreign Key------
    public int RecruiterId {get; set;}

    //----Navigation Property-----
    [ForeignKey(nameof(RecruiterId))]
    public User? Recruiter {get; set;}

    public DateTime CreatedAt {get; set;}

}

public enum JobType {
    Remote,
    City
}