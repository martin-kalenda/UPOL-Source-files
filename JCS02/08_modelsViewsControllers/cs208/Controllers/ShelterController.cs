using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cs208.Controllers
{
    // Controls shelter related actions
    public class ShelterController : BaseController
    {
        // Display the details of a shelter with given ID
        public IActionResult ShelterDetails(int shelterID, sbyte added = 0)
        {
            var shelter = Ctx.Shelters.Include(s => s.Dogs).FirstOrDefault(s => s.Id == shelterID); // retrieve the shelter with the specified ID
            if (shelter == null)
            {
                // redirect to landing page where user will be alerted of an error
                return RedirectToAction("Index", "Home", new { notFound = true });
            }
            return View((Shelter: shelter, Added: added));
        }
    }
}
