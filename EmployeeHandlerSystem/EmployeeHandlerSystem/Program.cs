using EmployeeHandlerSystem.Integration;
using EmployeeHandlerSystem.Integration.Refit;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRefitClient<IApiLoginIntegrationRefit>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("http://localhost:44369/");
});

builder.Services.AddScoped<IApiLoginIntegration, ApiLoginIntegration>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
