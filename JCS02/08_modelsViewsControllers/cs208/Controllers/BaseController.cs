using Microsoft.AspNetCore.Mvc;
using cs208.Models;

namespace cs208.Controllers
{
    // Ancestor class for the all other controllers, provides database context
    public class BaseController : Controller
    {
        protected Context Ctx { get; set; } = new Context(); // database context
    }
}
