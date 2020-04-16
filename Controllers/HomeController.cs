using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beryl.Models;
using Beryl.Data;

namespace Beryl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BerylInMemoryContext _inMemoryContext;

        public HomeController(ILogger<HomeController> logger, BerylInMemoryContext inMemoryContext)
        {
            _logger = logger;
            _inMemoryContext = inMemoryContext;
        }

        public IActionResult Index()
        {
            return Content("no redirect id specified.");
        }

        public IActionResult Redirect(int? id)
        {
            if (id == null)
                return Content("no redirect id specified.");

            var r = _inMemoryContext.Redirects.FirstOrDefault(x => x.RedirectId == id);

            if (r == null)
                return Content("no matching redirect found.");

            return Redirect(r.Url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
