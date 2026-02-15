using WoodWorld.Application.Rentals.Commands;
using WoodWorld.Domain;

namespace WoodWorld.Application.Services
{
    public interface IRentalService
    {
        Task<Rental> GetRentalById(Guid id);
        Task<IEnumerable<Rental>> GetActiveRentals();
        Task<IEnumerable<Rental>> GetRentalsByDateRange(DateOnly startDate, DateOnly endDate);
        Task<IEnumerable<Rental>> GetAllRentalsForUser(Guid userId);
        Task<IEnumerable<Rental>> GetAllRentalsForTool(Guid id);
        Task<Rental> CreateRental(decimal dailyRate, CreateRentalCommand req);
        Task<int> UpdateRental(UpdateRentalRequest request);
        Task<int> DeleteRental(Guid id);
    }
}
