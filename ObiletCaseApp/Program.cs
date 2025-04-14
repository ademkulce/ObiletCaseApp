using ObiletCaseApp.ApiClients.Abstract;
using ObiletCaseApp.ApiClients.Concrete;
using ObiletCaseApp.Models.Api;
using ObiletCaseApp.Services.Abstract;
using ObiletCaseApp.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<ObiletApiSettings>(builder.Configuration.GetSection("ObiletApiSettings"));

builder.Services.AddHttpClient<IObiletApiClient, ObiletApiClient>();

builder.Services.AddScoped<IObiletService, ObiletService>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
