using Business;
using Business.Contracts;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using WebApplicationDemo.Middleware;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MessagesContext>(ob
    => ob.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ASPNetDemo;Integrated Security=True"));

//builder.Services.AddScoped<IRandomGenService, RandomGenSuperService>();
builder.Services.AddScoped<IRandomGenService, RandomGenService>();
builder.Services.AddTransient<IMessageBusiness, MessageBusiness>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();

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

//New Middleware
app.Use404Middleware();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
