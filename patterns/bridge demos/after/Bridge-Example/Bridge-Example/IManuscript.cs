namespace Bridge_Example
{
    public abstract class Manuscript
    {
        protected readonly IFormatter formatter;

        public Manuscript(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        abstract public void Print();
    }
}