using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Rentals.Queries
{
    public class GetRentalByIdQuery : IRequest<Result<RentalDto>>
    {
    }

    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, Result<RentalDto>>
    {
        private readonly IRentalService _rentalService;

        public GetRentalByIdQueryHandler(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        Task<Result<RentalDto>> IRequestHandler<GetRentalByIdQuery, Result<RentalDto>>.Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}