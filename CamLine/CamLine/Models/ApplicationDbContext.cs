using Microsoft.EntityFrameworkCore;

namespace CamLine.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RegistraionForm> RegistraionForms { get; set; }
    }
}
