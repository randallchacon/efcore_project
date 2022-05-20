using efcore_project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HomeworksContext>(p => p.UseInMemoryDatabase("HomeworksDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] HomeworksContext dbContext) =>
{
    dbContext.Database.EnsureCreated(); //if the database does not exist, it will be created
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.Run();
