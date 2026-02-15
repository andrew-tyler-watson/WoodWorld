using WoodWorld.Application.Users.Commands;
using WoodWorld.Domain;

namespace WoodWorld.Application.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);
        Task<User> CreateUser(CreateUserCommand request);
        Task<int> UpdateUser(UpdateUserCommand request);
        Task<int> DeleteUser(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<int> UpdateUser(Guid id, UpdateUserCommand request);
    }
}
