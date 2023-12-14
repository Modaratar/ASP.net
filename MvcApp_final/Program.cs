using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb;Database = passengerstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();
builder.Services.AddHostedService<BackgroundWorkerService>();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();