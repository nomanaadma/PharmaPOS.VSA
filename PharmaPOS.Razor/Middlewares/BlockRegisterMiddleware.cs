namespace PharmaPOS.Razor.Middlewares;

public class BlockRegisterMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context)
	{
		if (context.Request.Path.StartsWithSegments("/Identity/Account/Register"))
		{
			context.Response.Redirect("/Identity/Account/Login");
			return;
		}

		await next(context);
	}
}