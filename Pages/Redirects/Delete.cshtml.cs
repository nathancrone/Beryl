using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beryl.Data;
using Beryl.Models;
using Beryl.Services;

namespace Beryl.Pages.Redirects
{
    public class DeleteModel : PageModel
    {
        private readonly Beryl.Data.BerylSqliteContext _context;

        private readonly ISeedService _seedService;

        public DeleteModel(ISeedService seedService, Beryl.Data.BerylSqliteContext context)
        {
            _seedService = seedService;
            _context = context;
        }

        [BindProperty]
        public Redirect RedirectLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RedirectLink = await _context.Redirects.FirstOrDefaultAsync(m => m.RedirectId == id);

            if (RedirectLink == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RedirectLink = await _context.Redirects.FindAsync(id);

            if (RedirectLink != null)
            {
                _context.Redirects.Remove(RedirectLink);
                await _context.SaveChangesAsync();
                _seedService.SeedRedirects();
            }

            return RedirectToPage("./Index");
        }
    }
}
