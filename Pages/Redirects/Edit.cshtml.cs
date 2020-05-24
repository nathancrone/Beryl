using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beryl.Data;
using Beryl.Models;
using Beryl.Services;

namespace Beryl.Pages.Redirects
{
    public class EditModel : PageModel
    {
        private readonly Beryl.Data.BerylSqliteContext _context;
        private readonly ISeedService _seedService;

        public EditModel(ISeedService seedService, Beryl.Data.BerylSqliteContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RedirectLink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _seedService.SeedRedirects();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedirectExists(RedirectLink.RedirectId))
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

        private bool RedirectExists(int id)
        {
            return _context.Redirects.Any(e => e.RedirectId == id);
        }
    }
}
