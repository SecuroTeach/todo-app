using ToDoApp.Api.Entites;

namespace ToDoApp.Api.Services;

public class ToDoService
{
    private List<ToDo> _toDos =
    [
        new ToDo { Id = 1, Content = "Buy milk" },
                new ToDo { Id = 2, Content = "Call mom" }
    ];

    public List<ToDo> GetAll()
    {
        return _toDos;
    }

    public void Create(string content)
    {
        var todo = new ToDo
        {
            Id = _toDos.Max(t => t.Id) + 1,
            Content = content
        };
        _toDos.Add(todo);
    }

    public void Delete(int id)
    {
        var todo = _toDos.FirstOrDefault(t => t.Id == id);
        if (todo is not null)
        {
            _toDos.Remove(todo);
        }
    }
}
