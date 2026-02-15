namespace WoodWorld.Application.Common
{
    public sealed record ValidationError(string Field, string Message);
    public class Result<T>
    {
        public string ErrorMessage { get; internal set; }

        public Result(T? value)
        {
            Value = value;
            IsSuccess = true;
        }

        public Result(ErrorType errorType, string errorMessage)
        {
            ErrorType = errorType;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; }
        public T? Value { get; }
        public ErrorType? ErrorType { get; init; }
    }
}
