using System;
using Autofac;
using System.Collections.Generic;

namespace AutoFac_InversionOfControl
{
    class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            builder.RegisterType<Dog>().As<IAnimal>();
            builder.RegisterType<Cat>().As<IAnimal>();
            Container = builder.Build();

            WriteDate();
            Console.WriteLine("");
            WriteHello();
            Console.WriteLine("");

            foreach (IAnimal animal in new List<IAnimal>() {
                new Dog(),
                new Cat()
            })
            {
                if (Container.IsRegistered<IAnimal>())
                {
                    using (var scope = Container.BeginLifetimeScope())
                    {
                        var reader = scope.Resolve<IEnumerable<IAnimal>>();
                        
                    }
                }

                using (var scope = Container.BeginLifetimeScope())
                {
                    scope.Resolve<IAnimal>().Eat();
                    scope.Resolve<IAnimal>().Sound();
                }
                //animal.Eat();
                //animal.Sound();
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                scope.Resolve<IDateWriter>().WriteDate();
            }
        }

        public static void WriteHello()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                scope.Resolve<IOutput>().Write("Hello World!!!");
            }
        }
    }

    // This interface helps decouple the concept of
    // "writing output" from the Console class. We
    // don't really "care" how the Write operation
    // happens, just that we can write.
    public interface IOutput
    {
        void Write(string content);
    }

    // This implementation of the IOutput interface
    // is actually how we write to the Console. Technically
    // we could also implement IOutput to write to Debug
    // or Trace... or anywhere else.
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    // This interface decouples the notion of writing
    // a date from the actual mechanism that performs
    // the writing. Like with IOutput, the process
    // is abstracted behind an interface.
    public interface IDateWriter
    {
        void WriteDate();
    }

    // This TodayWriter is where it all comes together.
    // Notice it takes a constructor parameter of type
    // IOutput - that lets the writer write to anywhere
    // based on the implementation. Further, it implements
    // WriteDate such that today's date is written out;
    // you could have one that writes in a different format
    // or a different date.
    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }
}
