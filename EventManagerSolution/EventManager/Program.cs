using System.Net;
using Auth0.AspNetCore.Authentication;
using EventManager.bll.Service;
using EventManager.bll.Service.Interfaces;
using EventManager.dal.Database;
using EventManager.dal.Repositories;
using EventManager.dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Chemins vers les certificats SSL
var certPath = Path.Combine(builder.Environment.ContentRootPath, "localhost.crt");
var keyPath = Path.Combine(builder.Environment.ContentRootPath, "localhost.key");

Console.WriteLine($"Chemin du certificat : {certPath}");
Console.WriteLine($"Chemin de la clé privée : {keyPath}");
/*
builder.WebHost.UseKestrel(options =>
{
    options.Listen(IPAddress.Loopback, 44300, listenOptions =>
    {
        listenOptions.UseHttps(certPath, keyPath); //
    });
});*/

// Configuration Auth0
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
    
    options.Scope = "openid profile email";
    options.OpenIdConnectEvents = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProvider = context =>
        {
            context.ProtocolMessage.RedirectUri = builder.Configuration["Auth0:CallbackUrl"];
            return Task.CompletedTask;
        }
    };
});

// Ajout des services
builder.Services.AddControllersWithViews();

// Connexion à la base de données
builder.Services.AddDbContext<DbContext_EventManager>(
    b => b.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
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
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();