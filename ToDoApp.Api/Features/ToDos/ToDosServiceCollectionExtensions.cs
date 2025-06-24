namespace ToDoApp.Api.Features.ToDos;

public static class ToDosServiceCollectionExtensions
{
    public static IServiceCollection AddToDos(this IServiceCollection services)
    {
        services.AddScoped<ToDoService>();
        services.AddScoped<ToDoRepository>();
        return services;
    }
} 