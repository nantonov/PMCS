namespace Schedule.Domain.Core.Exceptions
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException()
        { }

        public EntityDoesNotExistException(string message) : base(message) { }

        public EntityDoesNotExistException(int id)
            : base($"Entity with Id {id} doesn't exist.") { }

        public EntityDoesNotExistException(int id, Exception innerException)
            : base($"Entity with Id {id} doesn't exist.", innerException) { }
    }
}

