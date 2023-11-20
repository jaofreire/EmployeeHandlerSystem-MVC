using EmployeeHandlerSystem.Helper;
using EmployeeHandlerSystem.Helper.Interface;
using EmployeeHandlerSystem.Infraestructure.Data;
using EmployeeHandlerSystem.Integration;
using EmployeeHandlerSystem.Integration.Refit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<EmployeeHandlerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
});

builder.Services.AddRefitClient<IApiLoginIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://localhost:44369/");
});

builder.Services.AddSession(x =>
{
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IApiLoginIntegration, ApiLoginIntegration>();
builder.Services.AddScoped<ISessionEmployee, SessionEmployee>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RegisterLogin}/{action=EnterSignInPage}/{id?}");

app.Run();
