using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Common.Mappers;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Tools.Queries
{
    public class GetActiveToolsQuery : IRequest<Result<IEnumerable<ToolDto>>>
    {
    }
    public class GetActiveToolsQueryHandler : IRequestHandler<GetActiveToolsQuery, Result<IEnumerable<ToolDto>>>
    {
        private readonly IToolService _toolService;

        public GetActiveToolsQueryHandler(IToolService toolService)
        {
            _toolService = toolService;
        }
        public async Task<Result<IEnumerable<ToolDto>>> Handle(GetActiveToolsQuery request, CancellationToken cancellationToken)
        {
            var tools = await _toolService.GetActiveTools();
            return new Result<IEnumerable<ToolDto>>(tools.Select(t => t.ToDto()));
        }
    }
}
