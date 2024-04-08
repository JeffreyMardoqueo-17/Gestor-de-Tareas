using Microsoft.AspNetCore.Authentication.Cookies;
using GestordeTareas.UI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GestordeTareasUIContextConnection")
    ?? throw new InvalidOperationException("Connection string 'GestordeTareasUIContextConnection' not found.");

builder.Services.AddDbContext<GestordeTareasUIContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GestordeTareasUIContext>();

// Registrar servicios personalizados
builder.Services.AddScoped<GestordeTareas.BL.ImagenesPruebaBL, GestordeTareas.BL.ImagenesPruebaBL>();
builder.Services.AddScoped<GestordeTareas.BL.TareaFinalizadaBL, GestordeTareas.BL.TareaFinalizadaBL>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Usuarios/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/home/index");
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
