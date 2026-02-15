using WoodWorld.Application.Rentals.Commands;
using WoodWorld.Application.Services;
using WoodWorld.Domain;
using WoodWorld.Infrastructure.Persistence;

namespace WoodWorld.Infrastructure.Services
{
    public class RentalService : IRentalService
    {
        private readonly WoodWorldContext _woodWorldContext;

        public RentalService(WoodWorldContext woodWorldContext)
        {
            _woodWorldContext = woodWorldContext;
        }

        public async Task<Rental> CreateRental(decimal dailyRate, CreateRentalCommand req)
        {

            var rental = new Rental
            {
                Id = Guid.NewGuid(),
                UserId = req.UserId,
                ToolId = req.ToolId,
                RentedAt = req.StartDate,
                DueAt = req.EndDate,
                DailyRateAtCheckout = dailyRate,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _woodWorldContext.AddAsync(rental);
            await _woodWorldContext.SaveChangesAsync();

            return rental;
        }

        public async Task<int> DeleteRental(Guid id)
        {
            var rental = await _woodWorldContext.Rentals.FindAsync(id);
            if (rental is null) return 0;
            if (rental.IsDeleted) return 0;
            rental.IsDeleted = true;
            _woodWorldContext.Rentals.Update(rental);
            return await _woodWorldContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rental>> GetActiveRentals()
        {
            throw new NotImplementedException();
        }

        public async Task<Rental> GetRentalById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsForTool(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsForUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rental>> GetRentalsByDateRange(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateRental(UpdateRentalRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
