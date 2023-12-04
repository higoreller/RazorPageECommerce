using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public ICollection<Dataset>? Datasets { get; set; }
    }
}
