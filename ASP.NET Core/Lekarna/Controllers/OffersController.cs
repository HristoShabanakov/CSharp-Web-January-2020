using Lekarna.ViewModels.Offers;
using Microsoft.AspNetCore.Mvc;

namespace Lekarna.Controllers
{
    public class OffersController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateOfferInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.Json(input);
        }
    }
} 
