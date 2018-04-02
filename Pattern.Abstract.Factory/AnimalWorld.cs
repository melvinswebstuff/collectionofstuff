namespace Pattern.Abstract.Factory
{
    class AnimalWorld

    {

        private Herbivore _herbivore;
        private Carnivore _carnivore;
        private Plant _plant;



        // Constructor

        public AnimalWorld(ContinentFactory factory)

        {

            _carnivore = factory.CreateCarnivore();

            _herbivore = factory.CreateHerbivore();

            _plant = factory.CreatePlant();

        }



        public void RunFoodChain()

        {

            _carnivore.Eat(_herbivore);
            _herbivore.Eat(_plant);
        }

    }
}
