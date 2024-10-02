using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController : ControllerBase
    {
        private IToDoListService _toDoListService;

        public ListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        [Route("GetToDoLists")]
        public async Task<IActionResult> GetToDoListsAsync()
        {
            var toDoLists = await _toDoListService.GetToDoListsAsync();
            return Ok(toDoLists);
        }

        [HttpGet]
        [Route("GetToDoListWithItems/{id}")]
        public async Task<IActionResult> GetToDoListWithItemsAsync(Guid id)
        {
            var toDoList = await _toDoListService.GetToDoListWithItemsAsync(id);
            return Ok(toDoList);
        }
    }
}
