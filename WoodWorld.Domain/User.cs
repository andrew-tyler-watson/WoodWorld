namespace WoodWorld.Domain
{
    public sealed class User
    {
        public User()
        {

        }
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public IReadOnlyCollection<Rental> Rentals => _rentals;

        public DateTimeOffset CreatedAt { get; set; }

        private readonly List<Rental> _rentals = new();
        public User(string email, string fullName)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
