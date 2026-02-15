using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;
using WoodWorld.Application.Tools.Commands;
using WoodWorld.Application.Tools.Queries;
using WoodWorld.Infrastructure.Persistence;

namespace WoodWorld.Api.Endpoints;

static class ToolsEndpoints
{
    public static IEndpointRouteBuilder MapToolsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tools")
            .WithTags("Tools");

        group.MapGet("/", async (Mediator sender) =>
        {
            var result = await sender.Send(new GetActiveToolsQuery());
            return result.MapToHttpResult();
        });

        group.MapGet("/{id:guid}", async (Guid id, WoodWorldContext db) =>
        {
            var t = await db.Tools.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return t is null
                ? Results.NotFound()
                : Results.Ok(new ToolDto(t.Id, t.Name, t.Category, t.DailyRate, t.IsActive, t.CreatedAt));
        });

        group.MapPost("/", async (CreateToolCommand req, IToolService service) =>
        {
            if (string.IsNullOrWhiteSpace(req.Name))
                return Results.BadRequest("Name is required.");
            if (req.DailyRate < 0)
                return Results.BadRequest("DailyRate must be >= 0.");

            var tool = await service.CreateTool(req);

            return Results.Created($"/api/tools/{tool.Id}",
                new ToolDto(tool.Id, tool.Name, tool.Category, tool.DailyRate, tool.IsActive, tool.CreatedAt));
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateToolRequest req, IToolService service) =>
        {
            var tool = await service.GetToolById(id);
            if (tool is null) return Results.NotFound();
            if (req.DailyRate.HasValue && req.DailyRate.Value < 0) return Results.BadRequest("DailyRate must be >= 0.");
            return Results.NoContent();
        });

        group.MapDelete("/{id:guid}", async (Guid id, IToolService service) =>
        {
            var tool = await service.GetToolById(id);
            if (tool is null) return Results.NotFound();

            var isAvailable = await service.IsToolAvailableById(id);
            if (!isAvailable) return Results.Conflict("Tool is currently rented and cannot be retired.");
            await service.DeleteTool(id);

            return Results.NoContent();
        });

        return app;
    }
}


