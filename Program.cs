using Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity_Framework.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB"));
        builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnTasks"));
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.MapGet("/dbConection", async ([FromServices] TaskContext dbContext) =>
        {
            dbContext.Database.EnsureCreated();
            return Results.Ok("Data base in memory " + dbContext.Database.IsInMemory());

        }
        );

        app.MapGet("/api/tasks", async ([FromServices] TaskContext dbContext) =>
        {
           // return Results.Ok( dbContext.tasks.Include(p => p.Category).Where(p=> p.PriorityTask== Entity_Framework.Models.Priority.Low));
            return Results.Ok( dbContext.tasks.Include(p => p.Category));
        }
        );

         app.MapGet("/api/categories", async ([FromServices] TaskContext dbContext) =>
        {
            //return Results.Ok( dbContext.Categories.Where(p=> p.CategoryImpact > 15));
             return Results.Ok( dbContext.Categories);
        }
        );

          app.MapPost("/api/tasks", async ([FromServices] TaskContext dbContext,[FromBody] Entity_Framework.Models.Task task) =>
        {
            task.TaskId = Guid.NewGuid();
            task.TaskDate = DateTime.Now;
            await dbContext.AddAsync(task);

            await dbContext.SaveChangesAsync();

            return Results.Ok();
        }
        );

        app.MapPut("/api/tasks/{id}", async ([FromServices] TaskContext dbContext,[FromBody] Entity_Framework.Models.Task task,[FromRoute] Guid id) =>
        {
            var taskCurrent =dbContext.tasks.Find(id);
            if(taskCurrent != null)
            {
                taskCurrent.CategoryId=task.CategoryId;
                taskCurrent.TaskTitle = task.TaskTitle;
                taskCurrent.PriorityTask = task.PriorityTask;
                taskCurrent.TaskDescription = task.TaskDescription;
                return Results.Ok();
            }
            

            await dbContext.SaveChangesAsync();

            return Results.NotFound();
        }
        );

         app.MapPut("/api/categories/{id}", async ([FromServices] TaskContext dbContext,[FromBody] Category category,[FromRoute] Guid id) =>
        {
            var categoryCurrent =dbContext.Categories.Find(id);

            if(categoryCurrent != null)
            {
                categoryCurrent.CategoryName = category.CategoryName;
                categoryCurrent.CategoryDescription = category.CategoryDescription;
                categoryCurrent.CategoryImpact = category.CategoryImpact;             
                
                //return Results.Ok();
            }
            

            await dbContext.SaveChangesAsync();

            return Results.NotFound();
        }
        );

         app.MapDelete("/api/tasks/{id}", async ([FromServices] TaskContext dbContext,[FromRoute] Guid id) =>
        {
            var taskCurrent =dbContext.tasks.Find(id);

            if(taskCurrent != null)
            {
                dbContext.Remove(taskCurrent);
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            }

            return Results.NotFound();
        }
        );

        app.Run();
    }
}