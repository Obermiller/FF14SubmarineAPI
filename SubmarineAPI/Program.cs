using Data;
using Data.Repositories.Submarines;
using Data.Repositories.Submarines.Interfaces;
using Logic.Submarines;
using Logic.Submarines.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(dc =>
{
    dc.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Implement reflection for these later
builder.Services.AddScoped<IPartLogic, PartLogic>();
builder.Services.AddScoped<ISubmarineLogic, SubmarineLogic>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<ISubmarineRepository, SubmarineRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
