using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuração do pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Página de erro personalizada em produção
}
app.UseStaticFiles(); // Permite servir arquivos estáticos (CSS, JS, imagens)

app.UseRouting(); // Define rotas

app.UseAuthorization(); // Autorização (para autenticação futura, se adicionares Identity)

// Define a rota padrão da aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplicação
app.Run();
