using ToDoApp.Core.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoListItemRepository
    {
        Task<List<ToDoListItem>> GetToDoListItemsAsync();
        Task<ToDoListItem> GetToDoListItemAsync(Guid id);
        Task<ToDoListItem> CreateToDoListItemAsync(Guid listId, ToDoListItem newToDoListItem);
        Task<ToDoListItem> UpdateToDoListItemAsync(Guid listId, ToDoListItem newToDoListItem);
        Task DeleteToDoListItemAsync(Guid id);
    }
}
