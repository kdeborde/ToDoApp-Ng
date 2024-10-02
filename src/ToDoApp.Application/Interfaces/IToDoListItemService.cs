using ToDoApp.Core.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoListItemService
    {
        Task<List<ToDoListItem>> GetToItemsAsync();
        Task<ToDoListItem> GetToDoListItemAsync(Guid id);
        Task<ToDoListItem> AddItemAsync(Guid listId, ToDoListItem newToDoListItem);
        Task<ToDoListItem> UpdateItemAsync(Guid listId, ToDoListItem newToDoListItem);
        Task DeleteItemAsync(Guid id);
    }
}
