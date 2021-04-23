using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5Play.Controllers
{
    [Route("/api/home")]
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ActionResult<Home>> Index()
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var home = new Home(0, "Melvin", "Carter");
            var home2 = home with { FirstName = "Willie" };
            return home2;
        }

        [Route("")]
        [HttpPost]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ActionResult<Home>> Index(int id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var home = new Home(id, "Melvin", "Carter");
            return home;
        }
    }

    public record Home(int id, string FirstName, string LastName);
}
