using Data.Common;
using Data.Repositories;
using Domain.Products;
using Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

var connectionString =
	builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<DatabaseContext>
	(optionsAction: options =>
	{
		options
			.UseLazyLoadingProxies();
		options
			// using Microsoft.EntityFrameworkCore;
			.UseSqlServer(connectionString: connectionString);
	});


builder.Services.AddScoped<Domain.Products.IProductRepository, ProductRepository>();
builder.Services.AddScoped<Domain.Factors.IFactorRepository, FactorRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
	endpoints.MapControllerRoute("default", "/{controller=Home}/{action=index}/{id?}");
	endpoints.MapControllerRoute("pagination1", "/{controller=home}/{action=index}/{product}/Page{PageNumber}");
	endpoints.MapControllerRoute("pagination2", "/{controller=home}/{action=index}/Page{PageNumber}");
	endpoints.MapControllerRoute("pagination3", "/{controller=home}/{action=index}/{product}");
	endpoints.MapDefaultControllerRoute();
});



app.Run();
