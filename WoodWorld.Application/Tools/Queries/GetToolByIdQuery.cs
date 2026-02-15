using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Tools.Queries
{
    public class GetToolByIdQuery : IRequest<Result<ToolDto>>
    {
    }
    public class GetToolByIdQueryHandler : IRequestHandler<GetToolByIdQuery, Result<ToolDto>>
    {
        private readonly IToolService _toolService;

        public GetToolByIdQueryHandler(IToolService toolService)
        {
            _toolService = toolService;
        }
        public Task<Result<ToolDto>> Handle(GetToolByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
