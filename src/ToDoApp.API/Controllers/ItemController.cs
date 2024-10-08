﻿using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Entities;

namespace ToDoApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IToDoListItemService _toDoListItemService;

        public ItemController(IToDoListItemService toDoListItemService)
        {
            _toDoListItemService = toDoListItemService;
        }

        [HttpPost]
        [Route("AddItem/{listId}")]
        public async Task<IActionResult> AddItemAsync(Guid listId, [FromBody] CreateToDoListItemDto newToDoListItemDto)
        {
            var newToDoListItem = new ToDoListItem
            {
                ToDoListId = listId,
                Description = newToDoListItemDto.Description
            };
            var toDoListItem = await _toDoListItemService.AddItemAsync(listId, newToDoListItem);
            return Ok(toDoListItem);
        }
    }
}
