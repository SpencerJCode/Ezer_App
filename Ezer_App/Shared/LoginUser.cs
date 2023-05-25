#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ezer_App.Shared
{
  public class LoginUser
  {
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string LogEmail { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string LogPassword { get; set; }
  }
}
