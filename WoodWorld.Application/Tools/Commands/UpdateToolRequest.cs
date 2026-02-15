using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Tools.Commands;

public record UpdateToolRequest(string? Name, string? Category, decimal? DailyRate, bool? IsActive) : IRequest<Result<int>>;

public class UpdateToolRequestHandler : IRequestHandler<UpdateToolRequest, Result<int>>
{
    private readonly IToolService _toolService;
    public UpdateToolRequestHandler(IToolService toolService)
    {
        _toolService = toolService;
    }
    public async Task<Result<int>> Handle(UpdateToolRequest request, CancellationToken cancellationToken)
    {
        var rows = await _toolService.UpdateTool(request);
        if(rows > 0)
        {
            return new Result<int>(rows);
        }
        else
        {
            return new Result<int>(ErrorType.InternalServerError, "Failed to update row");
        }
    }
}