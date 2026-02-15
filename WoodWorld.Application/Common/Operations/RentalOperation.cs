namespace WoodWorld.Application.Common.Operations
{
    public class RentalOperation : Operation
    {
        public RentalOperation() : base($"Rental") { }
    }
    public class userOperation : Operation
    {
        public userOperation() : base($"User") { }
    }
    public class ToolOperation : Operation
    {
        public ToolOperation() : base($"Tool") { }
    }

    public abstract class Operation
    {
        protected Operation(string entityName)
        {
            _entityName = entityName;
        }
        private string _entityName;
        public string NotFoundMessage(Guid id)
        {
            return $"Failed to find {_entityName} with id {id}";
        }
        public string UnauthorizedMessage()
        {
            return $"Unauthorized access";
        }
        public string ForbiddenMessage(string operation, Guid id)
        {
            return $"Forbidden access: {operation} not allowed on {_entityName} with Id {id}";
        }
        public string ConflictMessage(Guid id)
        {
            return $"Conflict occurred for {_entityName} with id {id}";
        }

    }
}