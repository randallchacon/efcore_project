namespace efcore_project.Models;

public class Homework{
    public Guid HomeworkId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual Category Category { get; set; }
}

public enum Priority{
    Low,
    Mid,
    High
}