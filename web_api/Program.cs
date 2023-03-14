using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using web_api.Middlewares;
using web_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c) =>
{
    c.SwaggerDoc("v1", new OpenApiInfo(){ Title = "Tic Tac Toe API", Version = "v1.0" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddTransient<ITicTacToeRepository, TicTacToeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();
app.MapControllers();

app.Run();
