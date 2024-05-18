using MatchEvent.Domain.Interfaces;
using MatchEvent.Repository.InMemmory;
using MatchEvent.Repository.Repositories;
using MatchEvents.Domain.Interfaces;
using MatchEvents.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injection dependency for services and repositories
builder.Services.AddScoped<IAcbMatchEventService, AcbMatchEventService>();
builder.Services.AddScoped<IInMemmoryRepository, InMemmoryRepository>();
builder.Services.AddScoped<IMatchEventApiRestRepository, MatchEventApiRestRepository>();

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
