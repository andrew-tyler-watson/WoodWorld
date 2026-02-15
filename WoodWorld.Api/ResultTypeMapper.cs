using System.Reflection.Metadata.Ecma335;
using WoodWorld.Application.Common;

namespace WoodWorld.Api
{
    public static class ResultTypeMapper
    {
        public static IResult MapToHttpResult<T>(this Result<T> result) => result switch
        {
            _ when result.IsSuccess => Results.Ok(result.Value),
            _ when result.ErrorType.HasValue => MapToProblemDetails(result.ErrorType.Value),

        };

        public static IResult MapToProblemDetails(ErrorType errorType) => errorType switch
        {
            ErrorType.NotFound => Results.NotFound(),
            ErrorType.Unauthorized => Results.Unauthorized(),
            ErrorType.Forbidden => Results.Forbid(),
            ErrorType.Conflict => Results.Conflict(),
            ErrorType.InternalServerError => Results.Problem(),
            _ => Results.Problem()
        };

        public static IResult MapToValidationProblem(IEnumerable<ValidationError> errors)
        {
            var errorDictionary = errors
                .GroupBy(e => e.Field)
                .ToDictionary(g => g.Key, g => g.Select(e => e.Message).ToArray());
            return Results.ValidationProblem(errorDictionary);
        }

    }
}
