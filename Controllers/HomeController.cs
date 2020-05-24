using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beryl.Models;
using Beryl.Data;
using Beryl.Services;

namespace Beryl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BerylInMemoryContext _inMemoryContext;
        private readonly ISeedService _seedService;

        public HomeController(ILogger<HomeController> logger, BerylInMemoryContext inMemoryContext, ISeedService seedService)
        {
            _logger = logger;
            _inMemoryContext = inMemoryContext;
            _seedService = seedService;
        }

        public IActionResult Index()
        {
            return Content("no redirect id specified.");
        }

        public IActionResult Redirect(int? id)
        {
            // if no id is specified
            if (id == null)
                return Content("no redirect id specified.");


            if (_inMemoryContext.Redirects.Count() == 0)
            {
                _seedService.SeedRedirects();
            }

            // get the redirect row by the id
            var r = _inMemoryContext.Redirects.FirstOrDefault(x => x.RedirectId == id);

            // if no redirect row is found
            if (r == null)
                return Content("no matching redirect found.");

            //redirect
            return Redirect(r.Url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
