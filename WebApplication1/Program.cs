global using ClassLibrary1.Model;
global using ClassLibrary1.Manager;
global using ClassLibrary1.Core;

using Microsoft.EntityFrameworkCore;
using WebApplication1;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using AutoMapper;

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


// Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(MappingProfile));
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();


builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<SystemUserManager>();
builder.Services.AddScoped<CompanyManager>();
builder.Services.AddScoped<TenantManager>();

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
