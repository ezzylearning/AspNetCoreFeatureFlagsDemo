using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreFeatureFlagsDemo.Data;
using AspNetCoreFeatureFlagsDemo.Models;

namespace AspNetCoreFeatureFlagsDemo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AspNetCoreFeatureFlagsDemo.Data.SportsDbContext _context;

        public CreateModel(AspNetCoreFeatureFlagsDemo.Data.SportsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stadiums == null || Stadium == null)
            {
                return Page();
            }

            _context.Stadiums.Add(Stadium);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
