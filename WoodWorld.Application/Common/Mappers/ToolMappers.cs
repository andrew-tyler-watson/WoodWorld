using System;
using System.Collections.Generic;
using System.Text;
using WoodWorld.Application.Dtos;
using WoodWorld.Domain;

namespace WoodWorld.Application.Common.Mappers
{
    public static class ToolMappers
    {
        public static ToolDto ToDto(this Tool tool)
        {
            return new ToolDto(tool.Id, tool.Name, tool.Category, tool.DailyRate, tool.IsActive, tool.CreatedAt);
        }
    }
}
