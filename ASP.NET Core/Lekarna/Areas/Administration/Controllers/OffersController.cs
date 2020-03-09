using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lekarna.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class OffersController : Controller 
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
