using System;

namespace Pattern.Abstract.Factory
{
    class FoodChain
    {
    }

    abstract class Plant
    {

    }

    abstract class Herbivore

    {
        public abstract void Eat(Plant p);
    }

    abstract class Carnivore

    {

        public abstract void Eat(Herbivore h);

    }



    class Grass : Plant
    {

    }

    class Wildebeest : Herbivore

    {
        public override void Eat(Plant p)
        {
            Console.WriteLine(this.GetType().Name + " eats " + p.GetType().Name);
        }
    }


    class Lion : Carnivore

    {

        public override void Eat(Herbivore h)

        {

            // Eat Wildebeest

            Console.WriteLine(this.GetType().Name +

              " eats " + h.GetType().Name);

        }

    }



    class Berry : Plant
    {

    }

    class Bison : Herbivore

    {
        public override void Eat(Plant p)
        {
            Console.WriteLine(this.GetType().Name + " eats " + p.GetType().Name);
        }
    }

    class Wolf : Carnivore

    {

        public override void Eat(Herbivore h)

        {

            // Eat Bison

            Console.WriteLine(this.GetType().Name +

              " eats " + h.GetType().Name);

        }

    }
}
