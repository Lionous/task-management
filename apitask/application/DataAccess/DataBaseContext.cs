using application.Config;
using application.Models;
using Microsoft.EntityFrameworkCore;

namespace application.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
            Automapper.Start();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string connectionString = AppSettings.GetConnetionStringSqLite();
                optionsBuilder.UseSqlite(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasConversion(v => v.ToString().ToLower(), v => Guid.Parse(v));
            });
            
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
