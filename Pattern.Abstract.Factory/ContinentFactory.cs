namespace Pattern.Abstract.Factory
{
    abstract class ContinentFactory
    {

        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();

        public abstract Plant CreatePlant();

    }
}
