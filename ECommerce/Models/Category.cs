namespace ECommerce.Models;

public class Category
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ICollection<Dataset>? Datasets { get; set; }
}