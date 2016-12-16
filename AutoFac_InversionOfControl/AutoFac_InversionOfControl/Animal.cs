using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_InversionOfControl
{
    abstract class Animal
    {
        public abstract void Eat();
        public virtual void Sound()
        {
            Console.WriteLine("Noise...Noise...Noise...");
        }
    }

    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Munch...Munch...Munch...");
        }
        public override void Sound()
        {
            Console.WriteLine("Woof...Woof...Woof...");
        }
    }

    class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Sip...Sip...Sip...");
        }

        public override void Sound()
        {
            Console.WriteLine("Meow...Meow...Meow...");
        }
    }
}
