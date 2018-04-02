using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            new Receive();
        }
    }
}
