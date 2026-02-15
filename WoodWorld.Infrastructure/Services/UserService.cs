using WoodWorld.Application.Services;
using WoodWorld.Domain;
using WoodWorld.Infrastructure.Persistence;


namespace WoodWorld.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly WoodWorldContext _woodWorldContext;

        public UserService(WoodWorldContext woodWorldContext)
        {
            _woodWorldContext = woodWorldContext;
        }
        public async Task<User> GetUserById(Guid id)
        {
            return await _woodWorldContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _woodWorldContext.Users.FindAsync(email);
        }
        public async Task<User> CreateUser(CreateUserCommand req)
        {
            var user = new User
            {
                Name = req.Name.Trim(),
                Email = req.Email.Trim(),
                CreatedAt = DateTimeOffset.UtcNow
            };

            _woodWorldContext.Users.Add(user);
            await _woodWorldContext.SaveChangesAsync();

            return user;
        }

        public async Task<int> UpdateUser(Guid id, UpdateUserRequest request)
        {
            var user = await GetUserById(id);

            if (request.Name != string.Empty)
                user.Name = request.Name?.Trim() ?? user.Name;
            if (request.Email != string.Empty)
                user.Email = request.Email?.Trim() ?? user.Email;

            return await _woodWorldContext.SaveChangesAsync();
        }

        public async Task<int> DeleteUser(Guid id)
        {
            var user = await GetUserById(id);
            user.IsActive = false;
            return await _woodWorldContext.SaveChangesAsync();
        }
    }
}
