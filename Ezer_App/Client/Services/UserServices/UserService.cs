using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace Ezer_App.Client.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;

    public UserService(HttpClient http, NavigationManager navigationManager)
    {
      _http = http;
      _navigationManager = navigationManager;
    }
    public List<User> Users { get; set; } = new List<User>();
    public User? User { get; set; } = new User();
    public async Task<User> CreateUser(User user)
    {
      var result = await _http.PostAsJsonAsync("api/user/create", user);
      if (result.IsSuccessStatusCode) {
        User? createdUser = await SetUser(result);
        return createdUser;
      }
      return null;
    }
    public async Task<User> LoginUser(LoginUser userSubmission)
    {
      var result = await _http.PostAsJsonAsync("api/user/login", userSubmission);
      Console.WriteLine(result.IsSuccessStatusCode);
      if (result.IsSuccessStatusCode)
      {
        User? loggedInUser = await SetUser(result);
        return loggedInUser;
      }
      return null;
    }
    private async Task<User> SetUser(HttpResponseMessage result)
    {
      User = await result.Content.ReadFromJsonAsync<User>();
      return User;
    }
    public async Task DeleteUser(int id)
    {
      var result = await _http.DeleteAsync($"api/user/{id}");
      // await SetUsers(result);
    }
    public async Task<WeekData> GetWeekData(string dueDate)
    {
      var result = await _http.GetFromJsonAsync<WeekData>($"api/user/weekdata/{dueDate}");
      if (result != null)
      {
        return result;
      }
      return null;
    }
    public async Task<User> GetSingleUser(int id)
    {
      Console.WriteLine("__________GET USER___________");
      var result = await _http.GetFromJsonAsync<User>($"api/user/{id}");
      if (result != null)
        return result;
      return null;
    }
    public async Task GetUsers()
    {
      Users = await _http.GetFromJsonAsync<List<User>>("api/user");
      Console.WriteLine("You're at the controller after the GetFromJson!");
      Console.WriteLine("==========================");
      // Users = result;
    }
    private async Task<List<User>> SetUsers(HttpResponseMessage result)
    {
      Users = await result.Content.ReadFromJsonAsync<List<User>>();
      return Users;
    }
    public async Task UpdateUser(User user)
    {
      // Console.WriteLine("_______FROM USER SERVICE ABOVE var result______");
      Console.WriteLine(user.UserId);
      Console.WriteLine(user.AddressCity);
      Console.WriteLine(user.AddressState);
      Console.WriteLine(user.AddressStreet);
      Console.WriteLine(user.AddressZipcode);
      Console.WriteLine(user.DueDate);
      Console.WriteLine(user.EmergencyFirstName);
      Console.WriteLine(user.EmergencyLastName);
      Console.WriteLine(user.EmergencyNumber);
      Console.WriteLine(user.IsDoula);
      Console.WriteLine(user.IsMidwife);
      Console.WriteLine(user.PhoneNumber);
      Console.WriteLine(user.SpouseFirstName);
      Console.WriteLine(user.SpouseLastName);
      Console.WriteLine(user.SpouseNumber);
      var result = await _http.PutAsJsonAsync<User>($"api/user/{user.UserId}", user);
      if (result.IsSuccessStatusCode) {
        // Console.WriteLine("Result below");
        // Console.WriteLine(result);
        // User? updatedUser = await SetUser(result);
        // Console.WriteLine("updatedUser below");
        // Console.WriteLine(updatedUser.DueDate);
        // return updatedUser;
      }
      // return null;
    }
  }
}