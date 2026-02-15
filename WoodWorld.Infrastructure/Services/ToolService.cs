using WoodWorld.Application.Services;
using WoodWorld.Application.Tools.Commands;
using WoodWorld.Domain;
using WoodWorld.Infrastructure.Persistence;

namespace WoodWorld.Infrastructure.Services
{
    public class ToolService : IToolService
    {
        private readonly WoodWorldContext _woodWorldContext;

        public ToolService(WoodWorldContext woodWorldContext)
        {
            _woodWorldContext = woodWorldContext;
        }
        public async Task<Tool> GetToolById(Guid id)
        {
            return await _woodWorldContext.Tools.FindAsync(id);
        }
        public async Task<Tool> CreateTool(CreateToolCommand req)
        {
            var tool = new Tool
            {
                Id = Guid.NewGuid(),
                Name = req.Name.Trim(),
                Category = req.Category?.Trim(),
                DailyRate = req.DailyRate,
                IsActive = req.IsActive ?? true,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _woodWorldContext.Tools.Add(tool);
            await _woodWorldContext.SaveChangesAsync();

            return tool;
        }

        public async Task<int> UpdateTool(Guid id, UpdateToolRequest req)
        {
            var tool = await GetToolById(id);

            if (!string.IsNullOrWhiteSpace(req.Name))
                tool.Name = req.Name.Trim();

            if (req.Category is not null)
                tool.Category = req.Category.Trim();

            if (req.DailyRate.HasValue)
            {
                tool.DailyRate = req.DailyRate.Value;
            }

            if (req.IsActive.HasValue)
                tool.IsActive = req.IsActive.Value;

            return await _woodWorldContext.SaveChangesAsync();
        }
        public async Task<bool> IsToolAvailableById(Guid id)
        {
            var tool = await GetToolById(id);
            if (tool is null) return false;

            if (tool.Rentals.Any(r => r.ReturnedAt is null))
            {
                return false;
            }

            return tool.IsActive;
        }
        public async Task<int> RetireTool(Guid id)
        {
            var tool = await GetToolById(id);
            if (tool is null) return 0;
            tool.Retire();
            return await _woodWorldContext.SaveChangesAsync();
        }

        public Task<int> DeleteTool(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tool>> GetActiveTools()
        {
            var tools = _woodWorldContext.Tools.Where(t => t.IsActive).ToList();
            return Task.FromResult(tools.AsEnumerable());
        }

        public Task<int> UpdateTool(UpdateToolRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
