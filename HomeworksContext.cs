using Microsoft.EntityFrameworkCore;
using efcore_project.Models;

namespace efcore_project;

public class HomeworksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Homework> Homeworks { get; set; } //collection must be plural

    public HomeworksContext(DbContextOptions<HomeworksContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Instead Data Annotations
    {
        modelBuilder.Entity<Category>(cat =>{
            cat.ToTable("Category");
            cat.HasKey(p => p.CategoryId);
            cat.Property(p => p.Name).IsRequired().HasMaxLength(150);
            cat.Property(p => p.Description);
            cat.Property(p => p.Effort);
        });

        modelBuilder.Entity<Homework>(h => {
            h.ToTable("Homework");
            h.HasKey(p => p.HomeworkId);
            h.HasOne(p=> p.Category).WithMany(p => p.Homeworks).HasForeignKey(p => p.CategoryId);
            h.Property(p => p.Title).IsRequired().HasMaxLength(200);
            h.Property(p => p.Description);
            h.Property(p => p.PriorityHomework);
            h.Property(p => p.CreationDate);       
            h.Ignore(p => p.Summary);     
        });
    }
}