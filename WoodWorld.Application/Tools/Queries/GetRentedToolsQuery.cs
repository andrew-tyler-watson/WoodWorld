using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Tools.Queries
{
    public class GetRentedToolsQuery : IRequest<Result<IEnumerable<ToolDto>>>
    {
    }
    public class GetRentedToolsQueryHandler : IRequestHandler<GetRentedToolsQuery, Result<IEnumerable<ToolDto>>>
    {
        private readonly IToolService _toolService;
        public GetRentedToolsQueryHandler(IToolService toolService)
        {
            _toolService = toolService;
        }
        public Task<Result<IEnumerable<ToolDto>>> Handle(GetRentedToolsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
