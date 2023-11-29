using IdentityService.Configurations;
using IdentityService.Data;
using IdentityService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Db Context
builder.Services.AddDbPostgresContext(builder.Configuration);

// Add Jwt Service
builder.Services.AddScoped<IJwtService, JwtService>();

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

try 
{
    DbInitializer.InitializeDatabase(app);
}catch(Exception ex)
{
    Console.WriteLine(ex);
}

app.Run();
