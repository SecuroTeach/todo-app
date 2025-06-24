using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Api.Features.ToDos;

public class ToDoUpdateModel
{
    [MinLength(5)]
    public required string Content { get; set; }

    [Required]
    public required int UserId { get; set; }
} 