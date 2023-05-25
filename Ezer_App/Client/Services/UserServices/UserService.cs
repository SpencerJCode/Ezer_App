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
    public User? User { get;set; } = new User();
    public async Task<User> CreateUser(User user)
    {
      var result = await _http.PostAsJsonAsync("api/user", user);
      User? createdUser = await SetUser(result);
      return createdUser;
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
    public async Task<User> GetSingleUser(int id)
    {
      var result = await _http.GetFromJsonAsync<User>($"api/user/{id}");
      if (result != null)
        return result;
      throw new Exception("User not found!");
    }
    public async Task GetUsers()
    {
      var result = await _http.GetFromJsonAsync<List<User>>("api/user");
      if (result != null)
        Users = result;
    }
    public async Task UpdateUser(User user)
    {
      var result = await _http.PutAsJsonAsync($"api/user/{user.UserId}", user);
      // await SetUsers(result);
    }
  }
}