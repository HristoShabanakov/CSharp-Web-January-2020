using Demo.Data;
using Demo.Models;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System.Linq;

namespace Demo.App.Controllers
{
    public class UserController : BaseController
    {
        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse LoginConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                string username = httpRequest.FormData["username"].ToString();
                string password = httpRequest.FormData["password"].ToString();

                User userFromDb = context.Users
                    .SingleOrDefault(user => user.Username == username 
                                            && user.Password == password);

                if(userFromDb == null)
                {
                    return this.Redirect("/login");
                }

                httpRequest.Session.AddParameter("username", userFromDb.Username);
            }

            return this.Redirect("/home");
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View();
        }

        public IHttpResponse RegisterConfirm(IHttpRequest httpRequest)
        {
            using (var context = new DemoDbContext())
            {
                string username = httpRequest.FormData["username"].ToString();
                string password = httpRequest.FormData["password"].ToString();
                string confirmPassword = httpRequest.FormData["confirmPassword"].ToString(); 

                if(password != confirmPassword)
                {
                    return this.Redirect("/register");
                }

                User user = new User
                {
                    Username = username,
                    Password = password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Redirect("/users/login");
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
                httpRequest.Session.ClearParameters();

                return this.Redirect("/");
        }
    }
}
