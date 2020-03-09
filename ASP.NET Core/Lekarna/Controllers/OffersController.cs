using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Lekarna.ViewModels.Offers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lekarna.Controllers
{
    public class OffersController : Controller
    {
        private readonly Cloudinary cloudinary;

        public OffersController(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

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

        public async Task<IActionResult> Upload()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"C:\Users\ACER\Pictures\Nurofen.jpg")
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return Redirect("/");
        }
    }
}
