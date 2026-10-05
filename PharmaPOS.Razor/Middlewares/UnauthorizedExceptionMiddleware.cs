namespace PharmaPOS.Razor.Middlewares;

public class UnauthorizedExceptionMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (UnauthorizedAccessException)
		{
			// Instead of crashing with a 500 Server Error, we gracefully set a 403 Forbidden.
			// This allows app.UseStatusCodePagesWithReExecute to redirect the user to the proper Status page.
			context.Response.StatusCode = StatusCodes.Status403Forbidden;
		}
	}
}
