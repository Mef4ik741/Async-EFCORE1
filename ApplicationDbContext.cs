using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : DbContext
{
    private string connectionString = "Server=localhost;Database=DZ;Trusted_Connection=True;TrustServerCertificate=True;";
    
    public DbSet<Student> Students { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString, options => 
            options.EnableRetryOnFailure());
    }
}