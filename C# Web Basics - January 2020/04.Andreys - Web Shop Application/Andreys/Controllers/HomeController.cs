namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProducts = productsService.GetAll();

                //asign where the view should appears.
                return this.View(allProducts, "Home");
            }

            return this.View();
        }

        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
