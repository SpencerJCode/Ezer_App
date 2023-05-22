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
    public async Task CreateUser(User user)
    {
      var result = await _http.PostAsJsonAsync("api/user", user);
      await SetUsers(result);
    }
    private async Task SetUsers(HttpResponseMessage result)
    {
      var response = await result.Content.ReadFromJsonAsync<List<User>>();
      Users = response;
      _navigationManager.NavigateTo("users");
    }
    public async Task DeleteUser(int id)
    {
      var result = await _http.DeleteAsync($"api/user/{id}");
      await SetUsers(result);
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
      var result = await _http.PutAsJsonAsync($"api/user/{user.Id}", User);
      await SetUsers(result);
    }
  }
}