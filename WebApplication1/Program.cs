global using ClassLibrary1.Model;
global using ClassLibrary1.Manager;
global using ClassLibrary1.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.AddSystemAutentication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(config.GetSection("ConnectionStrings").GetValue<string>("ConntectionSQL")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(opption =>
{
    opption.AddDefaultPolicy(config =>
    {
        config.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDataProtection();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<SystemUserManager>();
builder.Services.AddScoped<CompanyManager>();
builder.Services.AddScoped<TenantManager>();
builder.Services.AddScoped<SecurityManager>();
builder.Services.AddScoped<SaleTransactionManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
