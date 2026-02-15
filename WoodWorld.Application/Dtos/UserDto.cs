namespace WoodWorld.Application.Dtos;

// -------------------- DTOs / REQUESTS --------------------

public record UserDto(Guid Id, string Name, string Email, DateTimeOffset CreatedAt);


