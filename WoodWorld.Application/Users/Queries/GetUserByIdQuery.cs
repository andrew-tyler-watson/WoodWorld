using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<Result<UserDto>>
    {
        public Guid UserId { get; set; }
    }
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUserService _userService;
        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
