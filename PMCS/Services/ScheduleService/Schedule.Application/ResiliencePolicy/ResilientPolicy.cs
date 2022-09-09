using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Schedule.Application.Configuration;

namespace Schedule.Application.RetryPolicy
{
    public static class ResilientPolicy
    {
        private static Random Jitter = new Random();

        public static AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => (int)message.StatusCode == 503)
                .CircuitBreakerAsync(ResilientPolicyConfiguration.ErrorsAmountBeforeBreaking, TimeSpan.FromSeconds(ResilientPolicyConfiguration.BreakingDurationInSeconds));

        public static AsyncRetryPolicy<HttpResponseMessage> TransientErrorRetryPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => (int)message.StatusCode >= 500 || (int)message.StatusCode == 429).WaitAndRetryAsync(ResilientPolicyConfiguration.RetryCount,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(Jitter.Next(0, 100)));

        //public static AsyncPolicyWrap<HttpResponseMessage> ResilientPolicyWrapper = CircuitBreakerPolicy.WrapAsync(TransientErrorRetryPolicy);

    }
}
