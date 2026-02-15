using MediatR;
using WoodWorld.Application.Common;
using WoodWorld.Application.Common.Mappers;
using WoodWorld.Application.Dtos;
using WoodWorld.Application.Services;

namespace WoodWorld.Application.Tools.Commands;

public record CreateToolCommand(string Name, string? Category, decimal DailyRate, bool? IsActive) : IRequest<Result<ToolDto>>;

public class CreateToolCommandHandler : IRequestHandler<CreateToolCommand, Result<ToolDto>>
{
    private readonly IToolService _toolService;
    public CreateToolCommandHandler(IToolService toolService)
    {
        _toolService = toolService;
    }
    public async Task<Result<ToolDto>> Handle(CreateToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _toolService.CreateTool(request);
        return new Result<ToolDto>(tool.ToDto());
    }
}