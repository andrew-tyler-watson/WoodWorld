using WoodWorld.Application.Tools.Commands;
using WoodWorld.Domain;

namespace WoodWorld.Application.Services
{
    public interface IToolService
    {
        public Task<Tool> CreateTool(CreateToolCommand req);
        Task<int> DeleteTool(Guid id);
        Task<IEnumerable<Tool>> GetActiveTools();
        Task<Tool> GetToolById(Guid id);
        Task<bool> IsToolAvailableById(Guid id);
        public Task<int> UpdateTool(UpdateToolRequest request);
    }
}
