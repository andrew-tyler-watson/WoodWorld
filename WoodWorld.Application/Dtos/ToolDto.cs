namespace WoodWorld.Application.Dtos;

public record ToolDto(Guid Id, string Name, string? Category, decimal DailyRate, bool IsActive, DateTimeOffset CreatedAt);


