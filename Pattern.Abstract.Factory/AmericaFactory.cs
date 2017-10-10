using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Abstract.Factory
{
    class AmericaFactory : ContinentFactory

    {

        public override Herbivore CreateHerbivore()

        {

            return new Bison();

        }

        public override Carnivore CreateCarnivore()

        {

            return new Wolf();

        }

        public override Plant CreatePlant()
        {
            return new Berry();
        }
    }
}
