using AltitudeTasks.Class;
using AltitudeTasks.Infrastructure;
using AltitudeTasks.Interfaces;
using AltitudeTasks.Repository;
using AltitudeTasks.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICounterForRequests, CounterForRequests>();
builder.Services.AddScoped<IInputService, InputService>();
builder.Services.AddScoped<IInputDataBase, InputDataBase>();
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
string connectionString = builder.Configuration.GetConnectionString("InputDataBase");
builder.Services.AddDbContext<InputDBContext>(options => options.UseSqlServer(connectionString));
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
