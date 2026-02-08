using System;
using System.Collections.Generic;

namespace WoodWorld.Domain
{
    public sealed class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Email { get; private set; }
        public string FullName { get; private set; }

        public bool IsActive { get; private set; } = true;

        public IReadOnlyCollection<RentalRecord> Rentals => _rentals;

        private readonly List<RentalRecord> _rentals = new();

        private User() { } // For ORM

        public User(string email, string fullName)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
