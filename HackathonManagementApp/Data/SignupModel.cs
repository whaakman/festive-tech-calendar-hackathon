using System.ComponentModel.DataAnnotations;
namespace HackathonManagement
{
    public class SignupModel
    {
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string TwitterAccount { get; set; }
    
    [Required]
    public string Email {get ; set; }
    
    [Required]
    public string SolutionUri { get; set; }

    public string ScoreCreativity { get; set; }

    public string ScoreTechnology { get; set; }

    public string ScoreWriteUp { get; set; }
    }
}

