namespace WoodWorld.Domain
{
    public sealed class Rental
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ToolId { get; set; }
        public Tool Tool { get; set; }

        public DateOnly RentedAt { get; set; }
        public DateOnly DueAt { get; set; }
        public DateOnly? ReturnedAt { get; set; }

        public bool IsReturned => ReturnedAt.HasValue;
        public bool IsOverdue => !IsReturned && DateOnly.FromDateTime(DateTime.UtcNow) > DueAt;
        public bool IsDeleted { get; set; }

        public decimal DailyRateAtCheckout { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Status
        {
            get
            {
                if (IsReturned)
                    return "Returned";
                if (IsOverdue)
                    return "Overdue";
                if (DateOnly.FromDateTime(DateTime.UtcNow) < RentedAt)
                    return "Scheduled";
                return "Active";
            }
        }

        public Rental() { } // For ORM

        public Rental(User user, Tool tool, DateOnly rentedAt, DateOnly dueAt)
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

        public void Return(DateOnly returnedAt)
        {
            if (IsReturned)
                throw new InvalidOperationException("Tool has already been returned.");

            ReturnedAt = returnedAt;
        }
    }
}
