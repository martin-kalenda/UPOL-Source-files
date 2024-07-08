using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using cs208.Models;
using Microsoft.EntityFrameworkCore;

namespace cs208.Controllers
{
    // Controls dog related actions
    public class DogController : BaseController
    {
        // Show dogs with given name that were not yet adopted
        public IActionResult Search(string searchedName)
        {
            var dogs = Ctx.Dogs.Include(d => d.Shelter).Where(d => d.Name != null && d.Adopted == false && d.Name.ToLower() == searchedName.ToLower()).ToList();
            ViewBag.SearchedName = searchedName; // pass the searched name to the view
            return View(dogs);
        }

        // Show detail page of a dog with given ID
        public IActionResult DogDetails(int dogID)
        {
            var dog = Ctx.Dogs.Include(d => d.Shelter).FirstOrDefault(d => d.Id == dogID); // find dog by ID and include the shelter navigation property

            if (dog == null)
            {
                // redirect to landing page where user will be alerted of an error
                return RedirectToAction("Index", "Home", new { notFound = true }); 
            }
            return View(dog);
        }

        // Open submission form for adding a new dog to a shelter with given ID
        [HttpGet]
        public IActionResult Add(int shelterID)
        {
            // options for select input
            ViewBag.SexOptions = new SelectListItem[]
            {
                new SelectListItem { Text = "pes", Value = "M" },
                new SelectListItem { Text = "fena", Value = "F" }
            };
            
            var shelter = Ctx.Shelters.FirstOrDefault(s => s.Id == shelterID); // find the shelter we are adding to
            
            if (shelter == null)
            {
                // redirect back to the shelter details page and notify the user of an error
                return RedirectToAction("ShelterDetails", "Shelter", new { added = -1 });
            }

            ViewBag.ShelterID = shelter.Id;     // pass the shelter ID to the view
            ViewBag.ShelterName = shelter.Name; // pass the shelter name to the view

            return View();
        }

        // Add the dog instance from the submission form to the database
        [HttpPost]
        public IActionResult Add(DogModel dog)
        {
            sbyte added = -1; // set added flag to error state

            ModelState.Remove("Shelter"); // remove shelter from the model state to prevent validation errors since this column is only used for the 1:N relationship

            if (ModelState.IsValid)
            {
                dog.Adopted = false;
                Ctx.Dogs.Add(dog);
                Ctx.SaveChanges();
                added = 1; // validation passed, set flag to OK state
            }
            // redirect to the details page of the shelter the dog was added to and notify user of the outcome
            return RedirectToAction("ShelterDetails", "Shelter", new { shelterID = dog.ShelterId, added });
        }

        // Change the adoption status of a dog with given ID to true
        public IActionResult Adopt(int dogID, bool fromDogDetail = false, bool fromDogSearch = false)
        {
            var dog = Ctx.Dogs.FirstOrDefault(d => d.Id == dogID); // find dog by ID

            if (dog == null)
            {
                // redirect to landing page where user will be alerted of an error
                return RedirectToAction("Index", "Home", new { notFound = true }); 
            }

            dog.Adopted = true;   // set the dog's adoption status to true
            Ctx.Dogs.Update(dog); // update the dog in the database
            Ctx.SaveChanges();    // save changes to the database

            // redirect to the appropriate page based on the origin of the request
            if (fromDogDetail)
            {
                return RedirectToAction("DogDetails", "Dog", new { dogID });
            }
            if (fromDogSearch)
            {
                return RedirectToAction("Search", "Dog", new { searchedName = dog.Name });
            }
            return RedirectToAction("ShelterDetails", "Shelter", new { shelterID = dog.ShelterId });
        }
    }
}
