using Microsoft.Framework.Configuration;
using System;

namespace Messenger.Services
{
    public class GreetingMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public interface IGreetingService
    {
        GreetingMessage GetTodaysGreeting();
    }

    public class GreetingService : IGreetingService
    {
        int _id = 1;
        IConfiguration _config;

        public GreetingService(IConfiguration config)
        {
            _config = config;
        }

        public GreetingMessage GetTodaysGreeting()
        {
            return new GreetingMessage
            {
                Id = _id++,
                Text = String.Format("Hello grom the greeting service #{0} {1}", _id, _config.Get("message"))
            };
        }
    }
}
