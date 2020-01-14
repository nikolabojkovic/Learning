namespace Demo.Interfaces
{
    public interface ICleanerFactory
    {
        ICleaner Create(string name1, string name2);
    }
}
