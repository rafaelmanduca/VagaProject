using Estacionamento.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EstacionamentoContext>(options =>
{
    options.UseMySql(
        builder
            .Configuration
            .GetConnectionString("EstacionamentoContext"),
        ServerVersion
        .AutoDetect(
            builder
                .Configuration
                .GetConnectionString("EstacionamentoContext")
            ) 
        );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Vaga/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vagas}/{action=Index}/{id?}");

app.Run();
