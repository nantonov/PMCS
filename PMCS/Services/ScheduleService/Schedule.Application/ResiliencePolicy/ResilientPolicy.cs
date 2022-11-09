using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;
using Schedule.Application.Configuration;
using Serilog;

namespace Schedule.Application.ResiliencePolicy
{
    public static class ResilientPolicy
    {
        private static readonly Random Jitter = new Random();

        private static readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .CircuitBreakerAsync(ResilientPolicyConfiguration.ErrorsAmountBeforeBreaking, TimeSpan.FromSeconds(ResilientPolicyConfiguration.BreakingDurationInSeconds));

        private static readonly AsyncRetryPolicy<HttpResponseMessage> TransientErrorRetryPolicy =
            Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode).WaitAndRetryAsync(
                ResilientPolicyConfiguration.RetryCount,
                retryAttempt =>
                {
                    var state = CircuitBreakerPolicy.CircuitState;

                    Log.Warning("Transient error. Retrying attempt {retryAttempt}. Circuit state is {CircuitState}", retryAttempt, state);

                    return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) +
                           TimeSpan.FromMilliseconds(Jitter.Next(0, 100));
                });

        public static readonly AsyncPolicyWrap<HttpResponseMessage> ResilientPolicyWrapper = CircuitBreakerPolicy.WrapAsync(TransientErrorRetryPolicy);
    }
}
