using ECommerce.Models;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Text.RegularExpressions;

namespace ECommerce.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IToastNotification _toastNotification;
        private IDatasetService _datasetService;
        public SelectList BrandOptionItems { get; set; }
        public SelectList CategoryOptionItems { get; set; }
        public EditModel(IDatasetService datasetService, IToastNotification toastNotification)
        {
            _datasetService = datasetService;
            _toastNotification = toastNotification;
        }
        [BindProperty]
        public Dataset Dataset { get; set; }
        [BindProperty]
        public IList<int> CategoryIds { get; set; }
        public void OnGet(int id) { 
            Dataset = _datasetService.GetDataset(id);
            CategoryIds = Dataset.Categories.Select(item => item.Id).ToList();
            BrandOptionItems = new SelectList(_datasetService.GetAllBrands(),
            nameof(Brand.Id),
                                                nameof(Brand.Description));

            CategoryOptionItems = new SelectList(_datasetService.GetAllCategories(),
                                                nameof(Category.Id),
                                                nameof(Category.Description));
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
            _datasetService.Update(Dataset);
            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostDelete()
        {
            _datasetService.Delete(Dataset.Id);
            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");
            return RedirectToPage("/Index");
        }
    }
}
