namespace PMCS.DLL.Exceptions
{
    public class InvalidNameIdentifierClaimException : Exception
    {
        public int StatusCode { get; } = 404;

        public InvalidNameIdentifierClaimException() { }

        public InvalidNameIdentifierClaimException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidNameIdentifierClaimException(string message) : base(message) { }
    }
}
