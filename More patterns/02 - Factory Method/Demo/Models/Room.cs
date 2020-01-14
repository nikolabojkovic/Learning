namespace Demo.Models
{
    public class Room
    {
        public string Label { get; set; }
        public decimal Area { get; set; }

        public override string ToString() =>
            $"Room {this.Label}";
    }
}
