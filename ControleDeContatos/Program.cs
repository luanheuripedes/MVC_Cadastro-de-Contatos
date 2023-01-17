using Data.Context;
using Data.Repositories;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("ContatoConnectionString");
builder.Services.AddDbContext<BancoContext>(options => options.UseMySql(connectionString,
                                                             ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IContatoRepositorie, ContatoRepositorie>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
