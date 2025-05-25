using Microsoft.EntityFrameworkCore;

namespace CamLine_Project.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RegistraionForm> RegistraionForms { get; set; }
    }
}
