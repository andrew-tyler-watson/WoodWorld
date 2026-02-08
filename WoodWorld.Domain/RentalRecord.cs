using System;
using WoodWorld.Domain;

namespace WoodWorld.Domain
{
    public sealed class RentalRecord
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid ToolId { get; private set; }
        public Tool Tool { get; private set; }

        public DateTimeOffset RentedAt { get; private set; }
        public DateTimeOffset DueAt { get; private set; }
        public DateTimeOffset? ReturnedAt { get; private set; }

        public bool IsReturned => ReturnedAt.HasValue;
        public bool IsOverdue => !IsReturned && DateTimeOffset.UtcNow > DueAt;

        private RentalRecord() { } // For ORM

        public RentalRecord(User user, Tool tool, DateTimeOffset rentedAt, DateTimeOffset dueAt)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Tool = tool ?? throw new ArgumentNullException(nameof(tool));

            UserId = user.Id;
            ToolId = tool.Id;

            RentedAt = rentedAt;
            DueAt = dueAt;

            if (dueAt <= rentedAt)
                throw new InvalidOperationException("Due date must be after rental date.");
        }

        public void Return(DateTimeOffset returnedAt)
        {
            if (IsReturned)
                throw new InvalidOperationException("Tool has already been returned.");

            ReturnedAt = returnedAt;
        }
    }
}
