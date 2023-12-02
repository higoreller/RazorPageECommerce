using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class EditModel : PageModel
    {
        private IDatasetService _datasetService;
        public EditModel(IDatasetService datasetService)
        {
            _datasetService = datasetService;
        }
        [BindProperty]
        public Dataset Dataset { get; set; }
        public void OnGet(int id) => Dataset = _datasetService.GetDataset(id);
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _datasetService.Update(Dataset);
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostDelete()
        {
            _datasetService.Delete(Dataset.Id);
            return RedirectToPage("/Index");
        }
    }
}
