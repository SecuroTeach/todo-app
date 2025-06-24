namespace ToDoApp.Api.Features.ToDos;

public class ToDo
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public required int UserId {  get; set; }
} 