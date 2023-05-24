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
    [Required]
    [EmailAddress]
    public string LogEmail { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string LogPassword { get; set; }
  }
}
