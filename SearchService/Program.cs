using Polly;
using Polly.Extensions.Http;
using SearchService.Configurations;
using SearchService.Data;
using SearchService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<UsersServiceHttpClient>().AddPolicyHandler(GetPolicy());

// ADD Automapper
builder.Services.AddAutoMapperProfiles();

// ADD Cors rules
builder.Services.AddAngularCors();

// ADD RabbitMQ
builder.Services.AddRabbitMQConfig(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// AddCors
app.UseCors("AppClientsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        await DbInitializer.InitDb(app);
    }catch(Exception e)
    {
        Console.WriteLine(e);
    }
});


app.Run();

static IAsyncPolicy<HttpResponseMessage> GetPolicy() 
    => HttpPolicyExtensions
    .HandleTransientHttpError()
    .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)        
    .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(5));