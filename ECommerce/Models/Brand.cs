namespace ECommerce.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Dataset> Datasets { get; set; }
    }
}
