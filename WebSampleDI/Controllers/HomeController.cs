using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSampleDI.Models;
using WebSampleDI.Services;

namespace WebSampleDI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScopedService scopedService;
        private readonly IScopedService scopedService2;
        private readonly ISingletonService singletonService;
        private readonly ITransientService transientService;
        private readonly ITransientService transientService2;

        public HomeController(ILogger<HomeController> logger, IScopedService scopedService, IScopedService scopedService2, ISingletonService singletonService, ITransientService transientService, ITransientService transientService2)
        {
            _logger = logger;
            this.scopedService = scopedService;
            this.scopedService2 = scopedService2;
            this.singletonService = singletonService;
            this.transientService = transientService;
            this.transientService2 = transientService2;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Scoped = scopedService.GetHashCode(),
                Scoped2 = scopedService2.GetHashCode(),
                Singleton = singletonService.GetHashCode(),
                Transient = transientService.GetHashCode(),
                Transient2 = transientService2.GetHashCode(),
            };
            return View(viewModel);
        }

    }  
}
