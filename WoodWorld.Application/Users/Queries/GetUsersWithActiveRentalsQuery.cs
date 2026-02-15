using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Users.Queries
{
    public class GetUsersWithActiveRentalsQuery : IRequest<Result<IEnumerable<UserDto>>>
    {
    }
    public class GetUsersWithActiveRentalsQueryHandler : IRequestHandler<GetUsersWithActiveRentalsQuery, Result<IEnumerable<UserDto>>>
    {
        public GetUsersWithActiveRentalsQueryHandler(IUserService userService)
        {

        }
        public Task<Result<IEnumerable<UserDto>>> Handle(GetUsersWithActiveRentalsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
