using System;
using System.Collections.Generic;
using WoodWorld.Domain;

namespace WoodWorld.Domain
{
    public sealed class Tool
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }
        public string Category { get; private set; }

        public bool IsActive { get; private set; } = true;

        public IReadOnlyCollection<RentalRecord> Rentals => _rentals;
        private readonly List<RentalRecord> _rentals = new();

        private Tool() { } // For ORM

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
