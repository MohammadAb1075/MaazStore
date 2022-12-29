using Data.Common;
using Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = 
    builder.Configuration.GetConnectionString("MazzDB");

builder.Services.AddDbContext<DatabaseContext>
	(optionsAction: options =>
	{
		options
			.UseLazyLoadingProxies();
		options
			// using Microsoft.EntityFrameworkCore;
			.UseSqlServer(connectionString: connectionString);
	});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	// **************************************************
	// UseDeveloperExceptionPage() -> using Microsoft.AspNetCore.Builder;
	app.UseDeveloperExceptionPage();
	// **************************************************
}
else
{
	// **************************************************
	// UseGlobalException() -> using Infrastructure.Middlewares;
	app.UseGlobalException();
	// **************************************************

	// **************************************************
	// UseExceptionHandler() -> using Microsoft.AspNetCore.Builder;
	app.UseExceptionHandler("/Errors/Error");
	// **************************************************

	// **************************************************
	// The default HSTS value is 30 days.
	// You may want to change this for production scenarios,
	// see https://aka.ms/aspnetcore-hsts
	// UseHsts() -> using Microsoft.AspNetCore.Builder; 
	app.UseHsts();
	// **************************************************
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{product}/Page{PageNumber}");
	endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
	endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{product}");
	endpoints.MapDefaultControllerRoute();
});



app.Run();
