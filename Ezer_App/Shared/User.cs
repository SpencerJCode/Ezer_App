#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ezer_App.Shared;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public bool IsMidwife { get; set; } = false;
    public bool IsDoula { get; set; } = false;
    public DateTime DueDate { get; set; }
    public string PhoneNumber { get; set; }
    public string AddressStreet { get; set; }
    public string AddressState { get; set; }
    public string AddressCity { get; set; }
    public string AddressZipcode { get; set; }
    public string EmergencyFirstName { get; set; }
    public string EmergencyLastName { get; set; }
    public string EmergencyNumber { get; set; }
    public string SpouseFirstName { get; set; }
    public string SpouseLastName { get; set; }
    public string SpouseNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int DoulaId { get; set; } = 0;
    public int MidwifeId { get; set; } = 0;

    [NotMapped]
    [Required]
    public string ConfirmPassword { get; set; }
}