using EnergySaverAPI.Application.Interfaces;
using EnergySaverAPI.Application.Services;
using EnergySaverAPI.Infrastructure.Persistence;
using EnergySaverAPI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register application services
builder.Services.AddScoped<IConsumoHistoricoService, ConsumoHistoricoService>();
builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<IPosteService, PosteService>();
builder.Services.AddScoped<MLService>();

// Register repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped<PosteRepository>();

// Configure database context
builder.Services.AddDbContext<EnergySaverDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Swagger
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
