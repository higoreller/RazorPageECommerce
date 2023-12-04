using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace ECommerce.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IDatasetService _datasetService;
        public SelectList BrandOptionItems { get; set; }
        public SelectList CategoryOptionItems { get; set; }
        public CreateModel(IDatasetService datasetService) {
            _datasetService = datasetService;
        }

        public void OnGet()
        {
            BrandOptionItems = new SelectList(_datasetService.GetAllBrands(),
                                                nameof(Brand.Id),
                                                nameof(Brand.Description));

            CategoryOptionItems = new SelectList(_datasetService.GetAllCategories(),
                                                nameof(Category.Id),
                                                nameof(Category.Description));
        }
        [BindProperty]
        public Dataset Dataset { get; set; }
        [BindProperty]
        public IList<int> CategoryIds
        {
            get; set;
        }
        public IActionResult OnPost() 
        {
            Dataset.Categories = _datasetService.GetAllCategories()
                                            .Where(item => CategoryIds.Contains(item.Id))
                                            .ToList();
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            _datasetService.Insert(Dataset);

            return RedirectToPage("/Index");
        }
    }
}
