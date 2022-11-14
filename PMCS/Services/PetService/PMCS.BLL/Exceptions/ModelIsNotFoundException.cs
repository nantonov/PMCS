namespace PMCS.BLL.Exceptions
{
    public class ModelIsNotFoundException : Exception
    {
        public int StatusCode { get; } = 404;
        public int ModelId { get; }

        public ModelIsNotFoundException() { }

        public ModelIsNotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public ModelIsNotFoundException(string message) : base(message) { }

        public ModelIsNotFoundException(int modelId, string message) : base(message)
        {
            ModelId = modelId;
        }

        public ModelIsNotFoundException(int modelId) : base($"Model with Id={modelId} doesn't exist.")
        {
            ModelId = modelId;
        }
    }
}
