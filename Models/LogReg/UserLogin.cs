using System.ComponentModel.DataAnnotations;

namespace UpdatedLogReg.Models
{
public class LoginUser
{
    [Required]
    [Display(Name = "Email")]
    public string LogEmail { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string LogPassword { get; set; }

}
}