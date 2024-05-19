namespace SchoolSis.API.Middlewares
{
  public class shabbatMiddleware
  {
    private readonly RequestDelegate _next;
    public shabbatMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
      DateTime today = DateTime.Now;

      bool shabbat = today.DayOfWeek == DayOfWeek.Saturday;

      if (shabbat)
      {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return;
      }
      await _next(context);
    }
  }
}
