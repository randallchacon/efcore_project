using System.ComponentModel.DataAnnotations;

namespace efcore_project.Models;

public class Category
{
    //[Key] //primary key
    public Guid CategoryId { get; set; }
    //[Required]
    //[MaxLength(150)] //
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; } //get all category homeworks 
}