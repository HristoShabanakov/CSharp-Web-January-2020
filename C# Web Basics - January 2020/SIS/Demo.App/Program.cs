using Demo.App.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Result;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            //[GET] Mappings
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", httpRequest 
                => new HomeController(httpRequest).Index(httpRequest));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/users/login", httpRequest
                => new UserController().Login(httpRequest));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/users/register", httpRequest
                => new UserController().Register(httpRequest));
            serverRoutingTable.Add(HttpRequestMethod.Get, "/users/logout", httpRequest
                => new UserController().Logout(httpRequest));


            serverRoutingTable.Add(HttpRequestMethod.Get, "/home", httpRequest
                => new HomeController(httpRequest).Home(httpRequest));

            //[Post] Mappings
            serverRoutingTable.Add(HttpRequestMethod.Post, "/users/login", httpRequest
                => new UserController().LoginConfirm(httpRequest));
            serverRoutingTable.Add(HttpRequestMethod.Post, "/users/register", httpRequest
                => new UserController().RegisterConfirm(httpRequest));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
