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
        public Brand Brand { get; private set; }
        public IActionResult OnGet(int id)
        {
            Dataset = _dataSetService.GetDataset(id);
            Brand = _dataSetService.GetAllBrands().SingleOrDefault(item=> item.Id == Dataset.BrandId);

            if(Dataset == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
