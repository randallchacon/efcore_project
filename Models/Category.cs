namespace efcore_project.Models;

public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Priority PriorityHomework { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; } //get all category homeworks 
}