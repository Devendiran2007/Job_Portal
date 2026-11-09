using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Portal.Backend.Models;

public class Job {

    public int Id {get; set;}

    public string Title {get; set;}

    public string Description {get; set;}

    public string Location {get; set;}

    public int Salary {get; set;}

    public string JobType {get; set;}

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