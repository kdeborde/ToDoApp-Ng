using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Entities;

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
        [Route("GetLists")]
        public async Task<IActionResult> GetListsAsync()
        {
            var toDoLists = await _toDoListService.GetToDoListsAsync();
            return Ok(toDoLists);
        }

        [HttpGet]
        [Route("GetListWithItems/{id}")]
        public async Task<IActionResult> GetListWithItemsAsync(Guid id)
        {
            var toDoList = await _toDoListService.GetToDoListWithItemsAsync(id);
            return Ok(toDoList);
        }

        [HttpPost]
        [Route("CreateList")]
        public async Task<IActionResult> CreateListAsync([FromBody] CreateToDoListDto newListDto)
        {
            var newToDoList = new ToDoList
            {
                Name = newListDto.Name
            };
            var toDoList = await _toDoListService.CreateToDoListAsync(newToDoList);
            return Ok(toDoList);
        }
    }
}
