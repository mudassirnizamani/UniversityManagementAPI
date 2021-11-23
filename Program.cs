using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityManagementAPI.Context;
using UniversityManagementAPI.Interfaces;
using UniversityManagementAPI.Models;
using UniversityManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var provider = builder.Services.BuildServiceProvider();
var configration = provider.GetRequiredService<IConfiguration>();

// Database Contexts - Mudasir Ali
builder.Services.AddDbContext<AuthContext>(opt => opt.UseSqlServer(configration.GetConnectionString("Default")));
builder.Services.AddDbContext<APIContext>(opt => opt.UseSqlServer(configration.GetConnectionString("Default")));


// Dependency Injection - Mudasir Ali
builder.Services.AddScoped<IFaculty, IFacultyService>();
builder.Services.AddScoped<IDepartment, IDepartmentService>();


// Identity Core Configration - Mudasir Ali
builder.Services.AddIdentityCore<UserModel>().AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthContext>();

builder.Services.Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.User.RequireUniqueEmail = false;
    }
);

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
