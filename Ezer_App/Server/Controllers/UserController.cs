﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Ezer_App.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly MyContext _context;
    public UserController(MyContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      List<User> users = await _context.Users.ToListAsync();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleUser(int id)
    {
      User? user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
      if (user == null)
      {
        return NotFound("User not found.");
      }
      return Ok(user);
    }

    [HttpGet("weekdata/{dueDate}")]
    public async Task<ActionResult<WeekData>> GetWeekData(DateTime dueDate)
    {
      // var DueDate = DateTime.Now.AddDays(20 * 7 + 1);
      DateTime dueDateDate = (DateTime)dueDate;
      // var DueDate = dueDateDate.AddDays(1);
      var DueDate = dueDateDate;
      var ConceptionDate = DateTime.Now;
      var TimeDiff = DueDate - ConceptionDate;
      int? NumOfWeeks = TimeDiff.Days / 7;
      WeekData? weekData = await _context.TheBumpData.FirstOrDefaultAsync(w => w.WeekId == NumOfWeeks);
      if(weekData == null) {
        return NotFound("Week data not found.");
      }
      return Ok(weekData);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginUser userSubmission)
    {
      User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
      if (userInDb == null)
      {
        return NotFound("User not found.");
      }
      PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
      var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);
      if (result == 0)
      {
        return NotFound("User not found.");
      }
      return Ok(userInDb);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateNewUser(User submittedUser)
    {

      User? newUser = new User();
      newUser.FirstName = submittedUser.FirstName;
      newUser.LastName = submittedUser.LastName;
      newUser.Email = submittedUser.Email;
      User? emailChecker = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
      if (emailChecker != null)
      {
        return NotFound("User already in database.");
      }
      PasswordHasher<User> Hasher = new PasswordHasher<User>();
      submittedUser.Password = Hasher.HashPassword(submittedUser, submittedUser.Password);
      newUser.Password = submittedUser.Password;
      _context.Users.Add(newUser);
      await _context.SaveChangesAsync();
      User? loggedInUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);
      // if (loggedInUser != null)
      // {

      // HttpContext.Session.SetInt32("UUID", loggedInUser.UserId);
      // HttpContext.Session.SetString("UserName", loggedInUser.FirstName);
      // User? UserDoula = await _context.Users.FirstOrDefaultAsync(u => u.DoulaId == loggedInUser.DoulaId);
      // User? UserMidwife = await _context.Users.FirstOrDefaultAsync(u => u.MidwifeId == loggedInUser.MidwifeId);
      // }
      return Ok(loggedInUser);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateUser(User UpdatedUser, int id)
    // {
    //     User? UserInDB = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    //     if (UserInDB == null)
    //     {
    //         return NotFound("No user found");
    //     }
    //     UserInDB.FirstName = UpdatedUser.FirstName;
    //     UserInDB.LastName = UpdatedUser.LastName;
    //     UserInDB.Email = UpdatedUser.Email;
    //     UserInDB.IsDoula = UpdatedUser.IsDoula;
    //     UserInDB.IsMidwife = UpdatedUser.IsMidwife;
    //     UserInDB.DueDate = UpdatedUser.DueDate;
    //     UserInDB.PhoneNumber = UpdatedUser.PhoneNumber;
    //     UserInDB.AddressStreet = UpdatedUser.AddressStreet;
    //     UserInDB.AddressCity = UpdatedUser.AddressCity;
    //     UserInDB.AddressState = UpdatedUser.AddressState;
    //     UserInDB.AddressZipcode = UpdatedUser.AddressZipcode;
    //     UserInDB.EmergencyFirstName = UpdatedUser.EmergencyFirstName;
    //     UserInDB.EmergencyLastName = UpdatedUser.EmergencyLastName;
    //     UserInDB.EmergencyNumber = UpdatedUser.EmergencyNumber;
    //     UserInDB.SpouseFirstName = UpdatedUser.SpouseFirstName;
    //     UserInDB.SpouseLastName = UpdatedUser.SpouseLastName;
    //     UserInDB.SpouseNumber = UpdatedUser.SpouseNumber;
    //     UserInDB.UpdatedAt = DateTime.Now;
    //     await _context.SaveChangesAsync();

    //     return Ok(await GetSingleUser(UserInDB.UserId));
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateUserDoula(int id)
    // {
    //     User? UserInDB = await _context.Users.FirstOrDefaultAsync(u => u.UserId == HttpContext.Session.GetInt32("UUID"));
    //     if (UserInDB == null)
    //     {
    //         return NotFound("No user found");
    //     }
    //     UserInDB.DoulaId = id;
    //     UserInDB.UpdatedAt = DateTime.Now;
    //     await _context.SaveChangesAsync();

    //     return Ok(await GetSingleUser(UserInDB.UserId));
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateUserMidwife(int id)
    // {
    //     User? UserInDB = await _context.Users.FirstOrDefaultAsync(u => u.UserId == HttpContext.Session.GetInt32("UUID"));
    //     if (UserInDB == null)
    //     {
    //         return NotFound("No user found.");
    //     }
    //     UserInDB.MidwifeId = id;
    //     UserInDB.UpdatedAt = DateTime.Now;
    //     await _context.SaveChangesAsync();

    //     return Ok(await GetSingleUser(UserInDB.UserId));
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      User? UserInDB = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
      if (UserInDB == null)
      {
        return NotFound("No user found.");
      }
      _context.Users.Remove(UserInDB);
      await _context.SaveChangesAsync();
      HttpContext.Session.Clear();
      return Ok();
    }

    private async Task<List<User>> GetDBUsers()
    {
      return await _context.Users.ToListAsync();
    }
  }
}
