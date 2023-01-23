using MinhaApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<Context, Context>();

var app = builder.Build();

app.MapControllers();



app.Run();
