namespace Ezer_App.Client.Services.UserService

{
  public interface IUserService
  {
    List<User> Users { get; set; }
    Task GetUsers();
    Task<User> GetSingleUser(int id);
    Task<WeekData> GetWeekData(string dueDate);
    // Task CreateUser(User user);
    Task<User> CreateUser(User user);
    Task<User> LoginUser(LoginUser userSubmission);
    // Task<User> UpdateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
  }
}