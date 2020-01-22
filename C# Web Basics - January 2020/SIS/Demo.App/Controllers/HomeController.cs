using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;

namespace Demo.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpRequest httpRequest)
        {
            this.HttpRequest = httpRequest;
        }

        public IHttpResponse Index(IHttpRequest httpRequest) 
        {
            return this.View();
        }

        public IHttpResponse Home(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.View();
        }

    }
}
