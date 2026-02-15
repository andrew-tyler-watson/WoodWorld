using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Users.Commands
{
    public class DeactivateUserCommand : IRequest<Result<int>>
    {
        public Guid UserId { get; set; }
    }
    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, Result<int>>
    {
        private readonly IUserService _userService;

        public DeactivateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result<int>> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
