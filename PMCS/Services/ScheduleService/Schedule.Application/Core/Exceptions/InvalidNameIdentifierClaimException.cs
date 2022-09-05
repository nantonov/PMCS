namespace Schedule.Application.Core.Exceptions
{
    public class InvalidNameIdentifierClaimException : Exception
    {
        public InvalidNameIdentifierClaimException()
        { }

        public InvalidNameIdentifierClaimException(string message) : base(message) { }

        public InvalidNameIdentifierClaimException(int id)
            : base($"Claim Id {id} is not valid.") { }
    }
}
