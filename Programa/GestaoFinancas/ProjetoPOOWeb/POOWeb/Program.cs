using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Permitir API + JSON
builder.Services.AddControllers();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Ativar CORS para permitir pedidos do front-end
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy
            .AllowAnyOrigin()   // Permite qualquer origem (ideal para desenvolvimento)
            .AllowAnyMethod()   // GET, POST, PUT, DELETE
            .AllowAnyHeader();  // Content-Type, Authorization, etc.
    });
});

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

// MUITO IMPORTANTE → ativar CORS antes do routing
app.UseCors("PermitirFrontEnd");

app.UseRouting();

app.UseSession();

// Mapear apenas Controllers (API)
app.MapControllers();

app.Run();
