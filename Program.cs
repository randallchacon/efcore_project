using efcore_project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using efcore_project.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<HomeworksContext>(p => p.UseInMemoryDatabase("HomeworksDB"));
builder.Services.AddSqlServer<HomeworksContext>(builder.Configuration.GetConnectionString("cnHomeworks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconnection", async ([FromServices] HomeworksContext dbContext) =>
{
    dbContext.Database.EnsureCreated(); //if the database does not exist, it will be created
    return Results.Ok("Database in memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("api/homeworks", async ([FromServices] HomeworksContext dbContext) =>
{
    //return Results.Ok(dbContext.Homeworks.Include(p => p.Category).Where(p => p.PriorityHomework == efcore_project.Models.Priority.Low));
    return Results.Ok(dbContext.Homeworks.Include(p => p.Category));
});

app.MapPost("api/homeworks", async ([FromServices] HomeworksContext dbContext, [FromBody] Homework homework) =>
{
    homework.HomeworkId = Guid.NewGuid();
    homework.CreationDate = DateTime.Now;
    await dbContext.AddAsync(homework);
    //await dbContext.Homeworks.AddAsync(homework); //another way

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("api/homeworks/{id}", async ([FromServices] HomeworksContext dbContext, [FromBody] Homework homework, [FromRoute] Guid id) =>
{
    var CurrentHomework = dbContext.Homeworks.Find(id);

    if(CurrentHomework != null){
        CurrentHomework.CategoryId = homework.CategoryId;
        CurrentHomework.Title = homework.Title;
        CurrentHomework.PriorityHomework = homework.PriorityHomework;
        CurrentHomework.Description = homework.Description;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
