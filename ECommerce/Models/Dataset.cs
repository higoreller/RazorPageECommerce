using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Dataset
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo 'Título' é obrigatório!")]
        public string Title { get; set; }

        public string SlugTitle => Title.ToLower().Replace(" ", "-");

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório!")]
        public string Description { get; set; }

        [Display(Name = "URL da Imagem")]
        [Required(ErrorMessage = "O campo 'URL da imagem' é obrigatório!")]
        public string ImageUrl { get; set; }

        [Display(Name = "Tamanho")]
        [Required(ErrorMessage = "O campo 'Tamanho' é obrigatório!")]
        [Range(1, int.MaxValue, ErrorMessage = "O tamanho deve ser um número positivo.")]
        public int Size { get; set; }

        [Display(Name = "Fonte")]
        [Required(ErrorMessage = "O campo 'Fonte' é obrigatório!")]
        public string Source { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo 'Categoria' é obrigatório!")]
        public string Category { get; set; }

        [Display(Name = "Data de criação")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Formato")]
        [Required(ErrorMessage = "O campo 'Formato' é obrigatório!")]
        public string Format { get; set; }
    }
}
