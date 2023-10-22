global using FastEndpoints;
global using FluentValidation;

using Offspace.Services.Outposts.API.Extensions;
using Offspace.Services.Outposts.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.UpdatePath();
builder.Configuration.UpdateApplicationSettings();
builder.Configuration.UpdateEnvironmentVariables();

var connectionString = Environment.GetEnvironmentVariable("CONNECTION")!;

builder.Services.AddDatabaseContexts(connectionString);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();