using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Beryl.Models;
using Beryl.Services;
using Microsoft.EntityFrameworkCore;

namespace Beryl.Pages
{
    public class ViewRedirectModel : PageModel
    {
        private readonly ILogger<ViewRedirectModel> _logger;
        private readonly Beryl.Data.BerylInMemoryContext _context;
        private readonly ISeedService _seedService;

        public ViewRedirectModel(ISeedService seedService, Beryl.Data.BerylInMemoryContext context, ILogger<ViewRedirectModel> logger)
        {
            _seedService = seedService;
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Redirect RedirectLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_context.Redirects.Count() == 0)
            {
                _seedService.SeedRedirects();
            }

            RedirectLink = await _context.Redirects.FirstOrDefaultAsync(m => m.RedirectId == id);

            if (RedirectLink == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
