using ToDoApp.Api.Features.Users;

namespace ToDoApp.Api.Features.ToDos;

public class ToDoDetailModel
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public required AuthorModel Author { get; set; }
}
