using MediatR;
using Microsoft.EntityFrameworkCore;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Rentals.Commands;

namespace WoodWorld.Api.Endpoints;

static class RentalsEndpoints
{
    public static IEndpointRouteBuilder MapRentalsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/rentals")
            .WithTags("Rentals");

        group.MapGet("/", async (IMediator sender) =>
        {
            var items = await sender.Send(new GetActiveRentalsQuery());


            return Results.Ok(
                items.Select(r => new RentalDto(
                    r.Id, r.UserId, r.ToolId, r.RentedAt, r.DueAt,
                    r.DailyRateAtCheckout, r.Status, r.CreatedAt))
                );
        });

        group.MapGet("/{id:guid}", async (Guid id, IMediator sender) =>
        {
            var r = await sender.Send(new GetRentalByIdQuery(id));
            return r is null
                ? Results.NotFound()
                : Results.Ok(new RentalDto(
                     r.Id, r.UserId, r.ToolId, r.RentedAt, r.DueAt,
                    r.DailyRateAtCheckout, r.Status, r.CreatedAt));
        });

        group.MapPost("/", async (CreateRentalCommand req, IMediator sender) =>
        {
            var rental = await sender.Send(req);

            return Results.Created($"/api/rentals/{rental.Id}", new RentalDto(
                rental.Id, rental.UserId, rental.ToolId, rental.RentedAt, rental.DueAt,
                rental.DailyRateAtCheckout, rental.Status, rental.CreatedAt));

            //if (req.UserId == Guid.Empty) return Results.BadRequest("UserId is required.");
            //if (req.ToolId == Guid.Empty) return Results.BadRequest("ToolId is required.");
            //if (req.EndDate < req.StartDate) return Results.BadRequest("EndDate must be >= StartDate.");

            //var user = await userService.GetUserById(req.UserId);
            //if (user is null) return Results.BadRequest("UserId does not exist.");

            //var tool = await toolService.GetToolById(req.ToolId);
            //if (tool is null) return Results.BadRequest("ToolId does not exist.");
            //if (!tool.IsActive) return Results.Conflict("Tool is inactive and cannot be rented.");

            //// Optional: prevent overlapping active rentals for the same tool
            //var overlaps = (await rentalService.GetActiveRentals()).Any(r =>
            //    r.ToolId == req.ToolId &&
            //    r.Status != "Returned" &&
            //    r.Status != "Scheduled" ||
            //    (
            //        r.Status == "Scheduled" &&
            //        req.StartDate <= r.DueAt &&
            //        req.StartDate >= r.RentedAt
            //    ));

            //if (overlaps) return Results.Conflict("Tool is already rented for that date range.");

            //var rental = await rentalService.CreateRental(tool.DailyRate, req);


        });

        group.MapPut("/{id:guid}", async (UpdateRentalRequest req, IMediator sender) =>
        {
            //var rental = await rentalService.GetRentalById(id);
            //if (rental is null) return Results.NotFound();

            //// Common edits: dates/status
            //if (req.StartDate.HasValue) rental.RentedAt = req.StartDate.Value;
            //if (req.EndDate.HasValue) rental.DueAt = req.EndDate.Value;
            //if (rental.DueAt < rental.RentedAt) return Results.BadRequest("EndDate must be >= StartDate.");

            //// Optional: re-check overlap if dates changed and still active
            //if (rental.Status is not ("Returned"))
            //{
            //    // Optional: prevent overlapping active rentals for the same tool
            //    var overlaps = (await rentalService.GetActiveRentals()).Any(r =>
            //        r.ToolId == req.ToolId &&
            //        r.Status != "Returned" &&
            //        r.Status != "Scheduled" ||
            //        (
            //            r.Status == "Scheduled" &&
            //            req.StartDate <= r.DueAt &&
            //            req.StartDate >= r.RentedAt
            //        ));

            //    if (overlaps) return Results.Conflict("Tool is already rented for that date range.");
            //}

            //await db.SaveChangesAsync();
            await sender.Send(req);
            return Results.NoContent();
        });

        group.MapDelete("/{id:guid}", async (Guid id, IMediator sender) =>
        {
            sender.Send(new DeleteRentalCommand(id));
            return Results.NoContent();
        });

        return app;
    }
}


