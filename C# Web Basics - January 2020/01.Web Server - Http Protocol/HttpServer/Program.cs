using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string NewLine = "\r\n";
            //Open a port
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);

            tcpListener.Start();

            //Infinity loop
            while (true)
            {
                //Info about the client
                TcpClient client = tcpListener.AcceptTcpClient();
                using (NetworkStream stream = client.GetStream())
                {
                    var requestBytes = new byte[100000];
                    //Returns the read bytes from the stream.
                    var readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
                    //Encoding text to byte and byte to text.
                    var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                    Console.WriteLine(new string('=', 70));
                    Console.WriteLine(stringRequest);

                    string responseBody = "<h1> Hello, user</h1>";
                       string response = "HTTP/1.0 200 OK" + NewLine + 
                        "MyCustomServer/1.0" + NewLine +
                        $"Content-Length: {responseBody.Length}" + NewLine + NewLine +
                        responseBody;

                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes, 0, response.Length);
                }
            }
        }
    }
}
