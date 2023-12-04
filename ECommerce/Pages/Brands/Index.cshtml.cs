using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly ECommerce.Data.DatasetDbContext _context;

        public IndexModel(ECommerce.Data.DatasetDbContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Brand != null)
            {
                Brand = await _context.Brand.ToListAsync();
            }
        }
    }
}
