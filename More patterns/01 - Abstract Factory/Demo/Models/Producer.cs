namespace Demo.Models
{
    public class Producer
    {
        public string Name { get; set; }

        public override string ToString() =>
            this.Name;
    }
}
