namespace ToDoApp.Api.Features.ToDos;

/// <summary>
/// This class contains endpoints to manage ToDo items.
/// </summary>
public static class Endpoints
{
    /// <summary>
    /// Maps the ToDo endpoints to the application.
    /// </summary>
    /// <param name="app">Endpoint route builder</param>
    public static void MapToDoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/todos")
            .WithTags("ToDos");

        group.MapGet("", async (ToDoService service) => await service.GetAllAsync());

        group.MapGet("{id:int}", async (int id, ToDoService service) =>
        {
            var toDo = await service.GetAsync(id);
            return Results.Ok(toDo);
        });

        group.MapPost("", async (ToDoUpdateModel model, ToDoService service) =>
        {
            await service.CreateAsync(model.Content, model.UserId);
            return Results.Ok();
        });

        group.MapPut("{id:int}", async (int id, ToDoUpdateModel model, ToDoService service) =>
        {
            await service.UpdateAsync(id, model.Content, model.UserId);
            return Results.Ok();
        });

        group.MapDelete("{id:int}", async (int id, ToDoService service) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok();
        });
    }
}
