using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Common.Operations;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Rentals.Commands;

public record UpdateRentalRequest(Guid Id, DateOnly? StartDate, DateOnly? EndDate, string? Status) : IRequest<Result<int>>;

public class UpdateRentalRequestHandler : RentalOperation, IRequestHandler<UpdateRentalRequest, Result<int>>
{
    private readonly IRentalService _rentalService;

    public UpdateRentalRequestHandler(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    public async Task<Result<int>> Handle(UpdateRentalRequest request, CancellationToken cancellationToken)
    {
        var rental = await _rentalService.GetRentalById(request.Id);
        if (rental == null) return new Result<int>(ErrorType.NotFound, NotFoundMessage(request.Id));

        var rows = await _rentalService.UpdateRental(request);

        if (rows == 0) return new Result<int>(ErrorType.InternalServerError, "Failed to update the rental.");
        return new Result<int>(rows);
    }
}