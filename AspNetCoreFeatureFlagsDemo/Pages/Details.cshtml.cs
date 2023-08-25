using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreFeatureFlagsDemo.Data;
using AspNetCoreFeatureFlagsDemo.Models;

namespace AspNetCoreFeatureFlagsDemo.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCoreFeatureFlagsDemo.Data.SportsDbContext _context;

        public DetailsModel(AspNetCoreFeatureFlagsDemo.Data.SportsDbContext context)
        {
            _context = context;
        }

      public Stadium Stadium { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums.FirstOrDefaultAsync(m => m.Id == id);
            if (stadium == null)
            {
                return NotFound();
            }
            else 
            {
                Stadium = stadium;
            }
            return Page();
        }
    }
}
