using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using Microsoft.AspNetCore.Cors;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer("User ID=sa;password=examlyMssql@123; server=localhost;Database=PlayerDb;trusted_connection=false;Persist Security Info=False;Encrypt=False;"));
builder.Services.AddCors(
    options =>{ options.AddDefaultPolicy(
        builder=>{
            builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
