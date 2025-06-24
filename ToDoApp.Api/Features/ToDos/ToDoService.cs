
using System.Threading.Tasks;

namespace ToDoApp.Api.Features.ToDos;

public class ToDoService
{
    private readonly ToDoRepository _toDoRepository;

    public ToDoService(ToDoRepository repository)
    {
        _toDoRepository = repository;
    }

    public async Task<List<ToDo>> GetAllAsync()
    {
        return await _toDoRepository.GetAllAsync();
    }

    public async Task<ToDoDetailModel?> GetAsync(int id)
    {
        return await _toDoRepository.GetWithAuthorAsync(id);
    }

    public async Task CreateAsync(string content, int userId)
    {
        await _toDoRepository.CreateAsync(content, userId);
    }

    public async Task DeleteAsync(int id)
    {
        await _toDoRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(int id, string content, int userId)
    {
        await _toDoRepository.UpdateAsync(id, content, userId);
    }
} 