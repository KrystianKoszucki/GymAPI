using System.Diagnostics;

namespace GymAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private readonly Stopwatch _stopWatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopWatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();

            await next.Invoke(context);

            _stopWatch.Stop();

            var miliseconds= _stopWatch.ElapsedMilliseconds;

            if(miliseconds/1000 >4)
            {
                var message = $"Request [{context.Request.Method}]" +
                    $"at {context.Request.Path} took {miliseconds}.";

                _logger.LogInformation(message);
            }
        }
    }
}
