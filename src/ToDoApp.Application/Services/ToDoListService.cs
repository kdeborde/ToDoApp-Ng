using ToDoApp.Application.Interfaces;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Application.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }
        public async Task<List<ToDoList>> GetToDoListsAsync()
        {
            return await _toDoListRepository.GetToDoListsAsync();
        }

        public async Task<ToDoList> GetToDoListWithItemsAsync(Guid id)
        {
            var toDoList = await _toDoListRepository.GetToDoListWithItemsAsync(id);
            toDoList.Items = toDoList.Items.OrderBy(x => x.Priority).ToList();
            return toDoList;
        }
    }
}
