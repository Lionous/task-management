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
                string? connectionString = AppSettings.GetConnetionStringSqLite();
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
            modelBuilder.Entity<Homework>().ToTable("tasks");
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasConversion(v => v.ToString().ToLower(), v => Guid.Parse(v));
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasConversion( v => v.ToString().ToLower(), v => Guid.Parse(v));
                entity.Property(e => e.status).HasConversion<string>();
                entity.Property(e => e.create_at).HasColumnName("create_at");
                entity.HasOne(e => e.Category)
                    .WithMany(e => e.ListTask)
                    .HasForeignKey(e => e.category_id);
            });
            
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
