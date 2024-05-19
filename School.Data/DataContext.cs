using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolSis.Utilities;

namespace SchoolSis
{
  public class DataContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DataContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
    }


  }
}
