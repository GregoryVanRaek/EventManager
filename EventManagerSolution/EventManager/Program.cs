using System.Net;
using Auth0.AspNetCore.Authentication;
using EventManager.bll.Service;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Database;
using EventManager.dal.Repositories;
using EventManager.dal.Repositories.Interfaces;
using EventManager.Support;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services
builder.Services.AddControllersWithViews();

// Configuration Auth0
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});

builder.Services.ConfigureSameSiteNoneCookies();

// Connexion à la base de données
builder.Services.AddDbContext<DbContext_EventManager>(
    b => b.UseSqlServer(builder.Configuration.GetConnectionString("Home"))
);

// Services d'application
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDaysRepository, DaysRepository>();
builder.Services.AddScoped<IDaysService, DaysService>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
builder.Services.AddScoped<IThemeService, ThemeService>();

var app = builder.Build();

// Configuration du pipeline de requête HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();