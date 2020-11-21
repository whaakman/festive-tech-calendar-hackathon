using System.ComponentModel.DataAnnotations;
namespace WebAppHackathon.Data
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
    
    [Required]
    public string Description { get; set; }
    }
}

