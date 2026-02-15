using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Users.Commands;

public record UpdateUserCommand(string? Name, string? Email) : IRequest<Result<int>>;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
{
    private readonly IUserService _userService;
    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<Result<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}