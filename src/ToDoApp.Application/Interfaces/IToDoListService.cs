using ToDoApp.Core.Entities;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoListService
    {
        public Task<List<ToDoList>> GetToDoListsAsync();
        public Task<ToDoList> GetToDoListWithItemsAsync(Guid id);
        public Task<ToDoList> CreateToDoListAsync(ToDoList newToDoList);
        public Task<ToDoList> UpdateToDoListAsync(ToDoList newToDoList);
        public Task DeleteToDoListAsync(Guid id);
    }
}
