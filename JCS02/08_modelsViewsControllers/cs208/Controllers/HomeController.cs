using cs208.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace cs208.Controllers
{
    // Controls the home page and basic functions
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        // Prepare the landing page
        public IActionResult Index(bool notFound = false)
        {
            List<ShelterModel> shelters = Ctx.Shelters.ToList(); // get list of all shelters in evidence
            return View((Shelters: shelters, NotFound: notFound));
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
