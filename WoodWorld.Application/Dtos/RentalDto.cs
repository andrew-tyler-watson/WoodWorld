namespace WoodWorld.Application.Dtos;

public record RentalDto(Guid Id, Guid UserId, Guid ToolId, DateOnly StartDate, DateOnly EndDate,
    decimal DailyRateAtCheckout, string Status, DateTimeOffset CreatedAt);


