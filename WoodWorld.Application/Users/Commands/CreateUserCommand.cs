using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Users.Commands;

public record CreateUserCommand(string Name, string Email) : IRequest<Result<UserDto>>;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
{
    private readonly IUserService _userService;
    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUser(request);
        return new UserDto(user.Id, user.Name, user.Email, user.CreatedAt);
    }
}