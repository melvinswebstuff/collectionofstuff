namespace Pattern.Abstract.Factory
{
    abstract class DocumentCreator
    {
        public abstract Letter CreateLetter();

        public abstract Resume CreateResume();
    }
}
