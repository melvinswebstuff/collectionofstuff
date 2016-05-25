using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DependencyDemo.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DependencyDemo.Controllers
{
    public class GreetingController : Controller
    {
        private IGreetingService _greetingService;
        private IGreetingService _greetingService2;

        public GreetingController(IGreetingService greetingService, IGreetingService greetingService2)
        {
            _greetingService = greetingService;
            _greetingService2 = greetingService2;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["message"] = _greetingService.GetGreeting() + " " + _greetingService2.GetGreeting();
            return View();
        }
    }
}
