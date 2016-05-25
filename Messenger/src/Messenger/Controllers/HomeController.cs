using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Messenger.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        IGreetingService _greeter;

        public HomeController(IGreetingService greeter)
        {
            _greeter = greeter;
        }
        // GET: /<controller>/
        public IActionResult Default()
        {
            var greeting = _greeter.GetTodaysGreeting();
            return View(greeting);
        }
    }
}
