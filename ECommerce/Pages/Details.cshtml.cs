using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class DetailsModel : PageModel
    {
        private IDatasetService _dataSetService;
        public DetailsModel(IDatasetService datasetService) {
            _dataSetService = datasetService;
        }
        public Dataset Dataset {  get; private set; }
        public IActionResult OnGet(int id)
        {
            Dataset = _dataSetService.GetDataset(id);

            if(Dataset == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
