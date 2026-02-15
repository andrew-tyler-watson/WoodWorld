using WoodWorld.Application.Services;

namespace WoodWorld.Application.Validations
{
    public class ToolExistsValidator<T> : IEndpointFilter
    {
        /// <summary>
        /// Validates that the toolId is non-empty and exists.
        /// Returns a dictionary compatible with Results.ValidationProblem(errors).
        /// </summary>
        public static async Task<Dictionary<string, string[]>> ValidateToolIdExistsAsync(
            Guid toolId,
            IToolService toolService,
            CancellationToken ct = default)
        {
            var errors = new Dictionary<string, string[]>();

            if (toolId == Guid.Empty)
            {
                errors["toolId"] = new[] { "toolId must be a non-empty GUID." };
                return errors;
            }

            var tool = await toolService.GetToolById(toolId);
            if (tool is null)
            {
                errors["toolId"] = new[] { $"No tool was found for toolId '{toolId}'." };
            }

            return errors;
        }
    }
}
