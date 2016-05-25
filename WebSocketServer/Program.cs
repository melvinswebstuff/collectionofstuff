using System;
using System.Net;
using System.Net.Sockets;

namespace WebSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 8110;
            TcpListener server = new TcpListener(IPAddress.Parse(ip), port);

            server.Start();
            Console.WriteLine("Server has started on " + ip + ":" + port + ".{0}Waiting for a connection...", Environment.NewLine);

            TcpClient client = server.AcceptTcpClient();

            NetworkStream stream = client.GetStream();

            //enter to an infinite cycle to be able to handle every change in stream
            while (true)
            {
                while (!stream.DataAvailable) ;

                Byte[] bytes = new Byte[client.Available];

                stream.Read(bytes, 0, bytes.Length);
            }

            Console.WriteLine("A client connected.");
            Console.Read();
        }
    }
}
