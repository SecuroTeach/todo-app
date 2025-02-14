using Microsoft.AspNetCore.Mvc;
using ToDoApp.Api.Entites;
using ToDoApp.Api.Models;
using ToDoApp.Api.Services;

namespace ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDosController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public List<ToDo> GetAll()
        {
            return _toDoService.GetAll();
        }

        [HttpPost]
        public IActionResult Create(ToDoUpdateModel model)
        {
            _toDoService.Create(model.Content);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _toDoService.Delete(id);
            return Ok();
        }
    }
}
