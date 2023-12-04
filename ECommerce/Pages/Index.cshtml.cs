using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class IndexModel : PageModel
    {
        private IDatasetService _dataSetService;
        public IndexModel(IDatasetService datasetService) {
            _dataSetService = datasetService;
        }
        public IList<Dataset> Datasets { get; set; }

        public void OnGet()
        {
            Datasets = _dataSetService.ListAll();
        }
    }
}