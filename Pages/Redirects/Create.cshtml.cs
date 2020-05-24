using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beryl.Services;
using Beryl.Models;

namespace Beryl.Pages.Redirects
{
    public class CreateModel : PageModel
    {
        private readonly Beryl.Data.BerylSqliteContext _context;
        private readonly ISeedService _seedService;

        public CreateModel(ISeedService seedService, Beryl.Data.BerylSqliteContext context)
        {
            _seedService = seedService;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Redirect RedirectLink { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Redirects.Add(RedirectLink);
            await _context.SaveChangesAsync();
            _seedService.SeedRedirects();

            return RedirectToPage("./Index");
        }
    }
}
