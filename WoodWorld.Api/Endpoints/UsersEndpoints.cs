using Microsoft.EntityFrameworkCore;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;
using WoodWorld.Application.Users.Commands;
using WoodWorld.Domain;

namespace WoodWorld.Api.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithTags("Users");

        group.MapGet("/{id:guid}", async (Guid id, IUserService service) =>
        {
            var u = await service.GetUserById(id);
            return u is null
                ? Results.NotFound()
                : Results.Ok(new UserDto(u.Id, u.Name, u.Email, u.CreatedAt));
        });

        group.MapPost("/", async (CreateUserCommand req, IUserService service) =>
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return Results.BadRequest("Name is required.");
            if (string.IsNullOrWhiteSpace(req.Email))
                return Results.BadRequest("Email is required.");

            var exists = (await service.GetUserByEmail(req.Email.Trim())) is not null;
            if (exists)
                return Results.Conflict("A user with that email already exists.");

            var user = await service.CreateUser(req);

            return Results.Created($"/api/users/{user.Id}", new UserDto(user.Id, user.Name, user.Email, user.CreatedAt));
        });

        //group.MapPut("/{id:guid}", async (Guid id, UpdateUserCommand req, IUserService service) =>
        //{
        //    var user = await service.GetUserById(id);
        //    if (user is null) return Results.NotFound();
        //    var exists = await service.GetUserByEmail(req.Email?.Trim() ?? "") is User existingUser && existingUsers.Id != id;
        //    if (exists) return Results.Conflict("A user with that email already exists.");

        //    if (string.IsNullOrWhiteSpace(req.Name) && string.IsNullOrWhiteSpace(req.Email))
        //        return Results.BadRequest("Name is required.");

        //    await service.UpdateUser(id, req);
        //    return Results.NoContent();
        //});

        group.MapDelete("/{id:guid}", async (Guid id, IUserService service) =>
        {
            var user = service.GetUserById(id);
            if (user is null) return Results.NotFound();

            await service.DeleteUser(id);

            return Results.NoContent();
        });

        return app;
    }
}
