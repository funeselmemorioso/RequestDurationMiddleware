using System.Diagnostics;

namespace API.MedirTiemposRequests.Middlewares
{
    // BASADO EN :
    // https://www.c-sharpcorner.com/article/measuring-and-reporting-the-response-time-of-an-asp-net-core-api/


    public class RequestsDurationMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestsDurationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var reloj = new Stopwatch();
            reloj.Start();

            context.Response.OnStarting(() => {

                reloj.Stop();
                var tiempoEnResponder = reloj.ElapsedMilliseconds;               
                context.Response.Headers["request-duracion"] = tiempoEnResponder.ToString() + " ms";
                
                // Mandar a una base desde aqui en un context (no inyectar por constructor)

                return Task.CompletedTask;
            });
            
            return this._next(context);           
        }
    }
}
