using System.ComponentModel.DataAnnotations.Schema;

namespace Job_Portal.Backend.Models;

public class Application {

    public int Id {get ; set;}

    //----ForeignKey----
    public int CandidateId  {get; set;}

    [ForeignKey(nameof(CandidateId))]
    public User? Candidate {get; set;}

    //----ForeignKey----
    public int JobId {get; set;}

    [ForeignKey(nameof(JobId))]
    public Job? Job {get; set;}

    public string Status {get; set;} = string.Empty;

    public  string? CoverLetter {get; set;}

    public DateTime AppliedAt {get; set;}

}