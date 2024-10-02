using ToDoApp.Core.Entities;

namespace ToDoApp.Core.Interfaces
{
    public interface IToDoListRepository
    {
        Task<List<ToDoList>> GetToDoListsAsync();
        Task<ToDoList> GetToDoListWithItemsAsync(Guid id);
        Task<ToDoList> CreateToDoListAsync(ToDoList newToDoList);
    }
}
