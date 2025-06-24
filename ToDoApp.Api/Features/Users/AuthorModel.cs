namespace ToDoApp.Api.Features.Users;

public class AuthorModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}
