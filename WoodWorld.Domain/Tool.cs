namespace WoodWorld.Domain
{
    public sealed class Tool
    {
        public Tool()
        {

        }
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Category { get; set; }

        public bool IsActive { get; set; } = true;

        public IReadOnlyCollection<Rental> Rentals => _rentals;

        public decimal DailyRate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        private readonly List<Rental> _rentals = new();

        public Tool(string name, string category)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Category = category ?? throw new ArgumentNullException(nameof(category));
        }

        public void Retire()
        {
            IsActive = false;
        }
    }
}
