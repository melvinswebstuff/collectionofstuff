using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_InversionOfControl
{
    interface IAnimal
    {
        void Eat();
        void Sound();
    }
    abstract class AnimalBehavior: IAnimal
    {
        public abstract void Eat();
        public virtual void Sound()
        {
            Console.WriteLine("Noise...Noise...Noise...");
        }
    }

    class Dog : AnimalBehavior
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

    class Cat : AnimalBehavior
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
