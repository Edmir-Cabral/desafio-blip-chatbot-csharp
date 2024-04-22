using DesafioBlipAPI.Controllers.Mapping;
using DesafioBlipAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGitHubBlipRepositorioCSharpService, GitHubBlipRepositorioCSharpService>();
builder.Services.AddScoped<GitHubApiService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

//Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000"; // Use 5000 como padrão se $PORT não estiver definido

app.Run($"http://*:{port}");
