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
    public class IndexModel : PageModel
    {
        private readonly Beryl.Data.BerylSqliteContext _context;

        public IndexModel(Beryl.Data.BerylSqliteContext context)
        {
            _context = context;
        }

        public IList<Redirect> RedirectLink { get; set; }

        public async Task OnGetAsync()
        {
            RedirectLink = await _context.Redirects.ToListAsync();
        }
    }
}
