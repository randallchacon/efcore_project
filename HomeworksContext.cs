using Microsoft.EntityFrameworkCore;
using efcore_project.Models;

namespace efcore_project;

public class HomeworksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Homework> Homeworks { get; set; } //collection must be plural

    public HomeworksContext(DbContextOptions<HomeworksContext> options) : base(options){ }
}