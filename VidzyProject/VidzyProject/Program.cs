using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VidzyProject.Configrations;
using VidzyProject.EntityConfigrations;

namespace VidzyProject
{
    public enum Classification
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3
    }
    public class VidzyContext : DbContext
    {
        
        public VidzyContext():base("name=DefaultConnection")
        {
            
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfigrations());
            modelBuilder.Configurations.Add(new GenerConfigrations());
            base.OnModelCreating(modelBuilder);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
