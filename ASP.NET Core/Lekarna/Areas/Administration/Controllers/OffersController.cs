using Microsoft.AspNetCore.Mvc;

namespace Lekarna.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class OffersController : Controller 
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
