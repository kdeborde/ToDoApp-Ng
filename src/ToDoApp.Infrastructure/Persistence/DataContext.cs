using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Entities;

namespace ToDoApp.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
    }
}
