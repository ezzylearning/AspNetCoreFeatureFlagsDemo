using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreFeatureFlagsDemo.Data;
using AspNetCoreFeatureFlagsDemo.Models;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace AspNetCoreFeatureFlagsDemo.Pages
{
    //[FeatureGate(ApplicationFeatures.StadiumsList)]
    public class IndexModel : PageModel
    {
        private readonly SportsDbContext _context;

        private readonly IFeatureManager _featureManager;

        public IndexModel(SportsDbContext context, IFeatureManager featureManager)
        {
            _context = context;
            _featureManager = featureManager;
        }

        public IList<Stadium> Stadium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (await _featureManager.IsEnabledAsync(ApplicationFeatures.StadiumsList))
            {
                if (_context.Stadiums != null)
                {
                    Stadium = await _context.Stadiums.ToListAsync();
                }
            }
            else
            {
                Stadium = new List<Stadium>();
            }
        }
    }
}
