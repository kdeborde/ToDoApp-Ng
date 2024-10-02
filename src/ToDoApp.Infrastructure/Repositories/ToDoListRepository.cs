using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Entities;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly DataContext _context;

        public ToDoListRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoList>> GetToDoListsAsync()
        {
            return await _context.ToDoLists.AsNoTracking().ToListAsync();
        }

        public async Task<ToDoList> GetToDoListWithItemsAsync(Guid id)
        {
            var toDoList = await _context.ToDoLists
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (toDoList == null)
            {
                throw new Exception("To-Do list not found");
            }

            return toDoList;
        }

        public async Task<ToDoList> CreateToDoListAsync(ToDoList newToDoList)
        {
            _context.ToDoLists.Add(newToDoList);
            await _context.SaveChangesAsync();
            return newToDoList;
        }
    }
}
