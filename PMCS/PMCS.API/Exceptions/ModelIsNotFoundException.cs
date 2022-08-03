namespace PMCS.API.Exceptions
{
    public class ModelIsNotFoundException : Exception
    {
        public int StatusCode { get; } = 404;
    }
}
