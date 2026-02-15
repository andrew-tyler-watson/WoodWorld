using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Common.Mappers;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Rentals.Queries
{
    public class GetActiveRentalsQuery : IRequest<Result<IEnumerable<RentalDto>>>
    {
    }
    public class GetActiveRentalsQueryHandler : IRequestHandler<GetActiveRentalsQuery, Result<IEnumerable<RentalDto>>>
    {
        private readonly IRentalService _rentalService;

        public GetActiveRentalsQueryHandler(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        public async Task<Result<IEnumerable<RentalDto>>> Handle(GetActiveRentalsQuery request, CancellationToken cancellationToken)
        {
            return new Result<IEnumerable<RentalDto>>((
                await _rentalService.GetActiveRentals())
                    .Select(r => r.ToDto())
                );
        }
    }
}