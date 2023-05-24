#pragma warning disable CS8618
namespace Ezer_App.Server.Data;

public class MyContext : DbContext
{
public MyContext(DbContextOptions options) : base(options) { }
public DbSet<User> Users { get; set; }
public DbSet<WeekData> TheBumpData { get;set; }
}