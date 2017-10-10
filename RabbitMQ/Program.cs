using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Rabbit MQ tutorial....");
            new Send();
        }
    }
}
