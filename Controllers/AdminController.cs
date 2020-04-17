using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beryl.Models;

namespace Beryl.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private IServiceProvider _serviceProvider;

        public AdminController(IServiceProvider serviceProvider, ILogger<AdminController> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Content("Hi from admin!");
        }

        public IActionResult Initialize()
        {
            DataGenerator.Initialize(_serviceProvider);
            return Content("Initialization complete.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
