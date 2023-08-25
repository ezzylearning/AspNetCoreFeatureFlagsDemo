using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreFeatureFlagsDemo.Data;
using AspNetCoreFeatureFlagsDemo.Models;

namespace AspNetCoreFeatureFlagsDemo.Pages
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreFeatureFlagsDemo.Data.SportsDbContext _context;

        public EditModel(AspNetCoreFeatureFlagsDemo.Data.SportsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadium =  await _context.Stadiums.FirstOrDefaultAsync(m => m.Id == id);
            if (stadium == null)
            {
                return NotFound();
            }
            Stadium = stadium;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(Stadium.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StadiumExists(int id)
        {
          return (_context.Stadiums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
