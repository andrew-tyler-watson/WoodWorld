using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Common.Operations;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Rentals.Commands
{
    public class DeleteRentalCommand : IRequest<Result<int>>
    {
        public Guid RentalId { get; set; }
    }
    public class DeleteRentalCommandHandler : RentalOperation, IRequestHandler<DeleteRentalCommand, Result<int>>
    {
        private readonly IRentalService _rentalService;

        public DeleteRentalCommandHandler(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        public async Task<Result<int>> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalService.GetRentalById(request.RentalId);
            if(rental is null) return new Result<int>(ErrorType.NotFound, NotFoundMessage(request.RentalId))
                    ;
            var output = await _rentalService.DeleteRental(request.RentalId);
            return new Result<int>(output);
        }
    }
}