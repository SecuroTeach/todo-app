using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Api.Models;

public class ToDoUpdateModel
{
    [MinLength(5)]
    public required string Content { get; set; }
}
