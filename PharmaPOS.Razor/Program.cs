using System.Globalization;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using PharmaPOS.Application;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Infrastructure;
using PharmaPOS.Infrastructure.Common.Persistence;
using PharmaPOS.Razor.Mappers;
using PharmaPOS.Razor.Middlewares;
using PharmaPOS.Razor.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddRazorPages();

builder.Services.AddAuthorization(options =>
{
	foreach (var perm in Permissions.GetAll())
	{
		options.AddPolicy(perm, policy =>
			policy.RequireAssertion(ctx =>
				ctx.User.HasClaim(c => c.Type == "Permission" && c.Value == perm)));
	}
});

builder.Services.AddApplication();

builder.Services.AddScoped<IFilePathProvider, FilePathProvider>();

var config = TypeAdapterConfig.GlobalSettings;
BillingMapper.Register(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	
	// using var scope = app.Services.CreateScope();
	// var dbInitializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
	// await dbInitializer.SeedAuthDataAsync();
}
else
{
	app.UseExceptionHandler("/Dashboard/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Dashboard/Status", "?code={0}");
app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<UnauthorizedExceptionMiddleware>();
app.UseMiddleware<BlockRegisterMiddleware>();

app.UseAuthorization();

app.MapStaticAssets();


app.MapRazorPages()
	.WithStaticAssets();

var defaultCulture = new CultureInfo("en-GB"); // en-GB uses dd/MM/yyyy naturally
var localizationOptions = new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture(defaultCulture),
	SupportedCultures = new List<CultureInfo> { defaultCulture },
	SupportedUICultures = new List<CultureInfo> { defaultCulture }
};
app.UseRequestLocalization(localizationOptions);

app.Run();