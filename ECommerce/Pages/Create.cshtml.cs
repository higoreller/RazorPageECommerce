using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class CreateModel : PageModel
    {
        private IDatasetService _datasetService;    
        public CreateModel(IDatasetService datasetService) {
            _datasetService = datasetService;
        }
        [BindProperty]
        public Dataset Dataset { get; set; }

        public IActionResult OnPost() 
        {
            if(!ModelState.IsValid) 
            {
                return Page();
            }
            _datasetService.Insert(Dataset);
            return RedirectToPage("/Index");
        }
    }
}
