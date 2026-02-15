using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Rentals.Commands;

public record CreateRentalCommand(Guid UserId, Guid ToolId, DateOnly StartDate, DateOnly EndDate) : IRequest<Result<RentalDto>>;

public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Result<RentalDto>>
{
    private readonly IRentalService _rentalService;
    private readonly IToolService _toolService;
    private readonly IUserService _userService;

    public CreateRentalCommandHandler(IRentalService rentalService, IToolService toolService, IUserService userService)
    {
        _rentalService = rentalService;
        _toolService = toolService;
        _userService = userService;
    }
    public async Task<Result<RentalDto>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var tool = await _toolService.GetToolById(request.ToolId);
        if(tool is null) return new Result<RentalDto>(ErrorType.NotFound, "Tool not found");

        var user = await _userService.GetUserById(request.UserId);
        if(user is null) return new Result<RentalDto>(ErrorType.NotFound, "User not found");

        //TODO: Check for overlaps. At the moment, this only checks if there are any active or overdue rentals for the tool,
        //but it doesn't check if the requested rental period overlaps with any existing rentals.
        //This could lead to double bookings if a tool is rented out for a future date while it is currently available.
        // It also misses the case where a tool is currently rented out but will be available during the requested rental period.
        var toolRentals = (await _rentalService
            .GetAllRentalsForTool(tool.Id))
            .Where(r => r.Status == "Active" || r.Status == "Overdue");
        if (toolRentals.Count() > 0) return new Result<RentalDto>(ErrorType.Conflict, "Tool altready rented for requested period.");

        var rental = await _rentalService.CreateRental(tool.DailyRate, request);
        var output = new RentalDto(rental.Id, rental.UserId, rental.ToolId, rental.RentedAt, rental.DueAt, rental.DailyRateAtCheckout, rental.Status, DateTime.UtcNow);
        return new Result<RentalDto>(output);
    }
}