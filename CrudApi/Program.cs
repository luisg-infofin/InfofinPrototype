using CrudApi.Configurations;
using CrudApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DBContext
builder.Services.AddDb(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add Repositories
builder.Services.AddRepositories();

// Add Authentication
builder.Services.AddJWTAuthentication(builder.Configuration["IdentityUrl"]);

// Add Automapper
builder.Services.AddAutoMapperProfiles();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}catch(Exception ex)
{
    Console.WriteLine("Error on seedeing DB: ", ex.Message);
}

app.Run();
