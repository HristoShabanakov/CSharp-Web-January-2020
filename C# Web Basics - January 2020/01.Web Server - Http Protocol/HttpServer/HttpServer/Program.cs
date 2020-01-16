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
                string responseBody = DateTime.Now.ToString();
                string response = "HTTP/1.0 200 OK" + NewLine +
                    "Content-Type: text/html" + NewLine +
                    "Set-Cookie: cookie1=test1" + NewLine +
                    "Set-Cookie: cookie2=test2" + NewLine +
                    "Server: MyCustomServer/1.0" + NewLine +
                    $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                    responseBody;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                await stream.WriteAsync(responseBytes, 0, response.Length);
            }
        }
    }
}


