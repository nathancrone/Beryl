using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beryl.Data;
using Beryl.Models;

namespace Beryl.Pages.Redirects
{
    public class DetailsModel : PageModel
    {
        private readonly Beryl.Data.BerylSqliteContext _context;

        public DetailsModel(Beryl.Data.BerylSqliteContext context)
        {
            _context = context;
        }

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
    }
}
