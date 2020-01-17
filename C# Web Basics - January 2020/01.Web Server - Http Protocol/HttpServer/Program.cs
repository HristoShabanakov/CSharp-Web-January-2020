using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Open a port
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);

            tcpListener.Start();

            //Infinity loop
            while (true)
            {
                //Info about the client
                TcpClient client = tcpListener.AcceptTcpClient();
                Task.Run(() => ProcessClient(client));
            }
        }
        public static async Task ProcessClient(TcpClient client)
        {
            const string NewLine = "\r\n";
            using (NetworkStream stream = client.GetStream())
            {
                byte[] requestBytes = new byte[100000];
                //Returns the read bytes from the stream.
                int readBytes = await stream.ReadAsync(requestBytes, 0, requestBytes.Length);
                //Encoding text to byte and byte to text.
                var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                Console.WriteLine(new string('=', 70));
                Console.WriteLine(stringRequest);

                //string responseBody = "<h1> Hello, user</h1>";
                string responseBody = stringRequest;
                string response = "HTTP/1.0 200 OK" + NewLine +
                    "Content-Type: text/plain" + NewLine +
                    //Domain attribute will enable cookies for all subdomains too.
                    "Set-Cookie: cookie1=test1; Domain=localhost; Security;" + NewLine +
                    //Without domain attribute cookies will be for the current site.
                    "Set-Cookie: cookie2=test2; Max-Age=30" + NewLine +
                    //Attributes Max-Age and Expires are for setting expiration time.
                    "Set-Cookie: cookie3=expiredemo; Expires=30" +
                    //Its important to use always DateTime.UtcNow to avoid time difference around the world.
                    DateTime.UtcNow.AddDays(7).ToString("R") + NewLine +
                    //Attribute Security will sent cookies only with https
                    "Set-Cookie: cookie4=jsmalwareprotection; HttpOnly;" + NewLine +
                    "Server: MyCustomServer/1.0" + NewLine +
                    $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                    responseBody;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes, 0, response.Length);
            }
        }
    }
}


