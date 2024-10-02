using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Application.Services
{
    public class ToDoListItemService : IToDoListItemService
    {
        private readonly IToDoListItemRepository _toDoListItemRepository;
        public ToDoListItemService(IToDoListItemRepository toDoListItemRepository)
        {
            _toDoListItemRepository = toDoListItemRepository;
        }

        public async Task<ToDoListItem> AddItemAsync(Guid listId, ToDoListItem newToDoListItem)
        {
            // TODO: Add validation, Add error handling, Add auto incrementing priority
            return await _toDoListItemRepository.CreateToDoListItemAsync(listId, newToDoListItem);
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoListItem> GetToDoListItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoListItem>> GetToItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ToDoListItem> UpdateItemAsync(Guid listId, ToDoListItem newToDoListItem)
        {
            throw new NotImplementedException();
        }
    }
}
