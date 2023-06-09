global using ClassLibrary1.Model;
global using ClassLibrary1.Manager;
global using ClassLibrary1.Core;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.


builder.AddSystemAutentication();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

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
        config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDataProtection();

builder.Services.AddHostedService<IntegrationMonitor>();
builder.Services.AddSingleton<RunBackground>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<SystemUserManager>();
builder.Services.AddScoped<CompanyManager>();
builder.Services.AddScoped<TenantManager>();
builder.Services.AddScoped<SecurityManager>();
builder.Services.AddScoped<SaleTransactionManager>();
builder.Services.AddScoped<TaskSaleTransactionManager>();
builder.Services.AddScoped<IntegrationManager>();
builder.Services.AddScoped<IntegrationBuilder>();
builder.Services.AddScoped<TestIntegrationManager>();

builder.Services.AddHttpClient("aeon", option =>
{
    option.BaseAddress = new Uri(config.GetSection("IntegrationSetting").GetValue<string>("AeonIntegrationUrl"));
});
builder.Services.AddHttpClient("test", option =>
{
    option.BaseAddress = new Uri(config.GetSection("IntegrationSetting").GetValue<string>("TestIntegrationUrl"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
