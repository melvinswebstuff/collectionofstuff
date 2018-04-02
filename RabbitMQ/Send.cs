using System;
using System.Text;
using RabbitMQ.Client;
using System.Threading;

namespace RabbitMQSend
{
    class Send
    {
        public Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello",
                        false,
                        false,
                        false,
                        null);

                    for (int i = 0; i < 10; i++)
                    {
                        string message = string.Format("Hello World {0}!", i);

                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish("",
                            "hello",
                            null,
                            body);

                        Console.WriteLine("[x] Sent {0}", message);
                        Thread.Sleep(5000);
                    }
                    
                }
            }

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
