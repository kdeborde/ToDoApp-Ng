using ToDoApp.Core.Entities;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoListItemRepository : IToDoListItemRepository
    {
        private DataContext _context;

        public ToDoListItemRepository(DataContext context)
        {
            _context = context;
        }
        public Task<ToDoListItem> GetToDoListItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToDoListItem>> GetToDoListItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ToDoListItem> CreateToDoListItemAsync(Guid listId, ToDoListItem newToDoListItem)
        {
            var toDoList = await _context.ToDoLists.FindAsync(listId);
            if (toDoList == null)
            {
                throw new ArgumentException("ToDoList not found", nameof(listId));
            }

            newToDoListItem.ToDoListId = listId;
            toDoList.Items.Add(newToDoListItem);
            await _context.SaveChangesAsync();
            return newToDoListItem;
        }

        public Task DeleteToDoListItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoListItem> UpdateToDoListItemAsync(Guid ListId, ToDoListItem toDoListItem)
        {
            throw new NotImplementedException();
        }
    }
}
