using ToDoApp.Core.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.ToDoLists.Any())
            {
                List<ToDoList> toDoList = new List<ToDoList>
                {
                    new ToDoList
                    {
                        Id = Guid.NewGuid(),
                        Name = "Around the house",
                        IsComplete = false,
                        IsInProgress = false,
                        Items = new List<ToDoListItem>
                        {
                            new ToDoListItem
                            {
                                Description = "Do dishes"
                            },
                            new ToDoListItem
                            {
                                Description = "Take Out Trash"
                            },
                            new ToDoListItem
                            {
                                Description = "Clean the garage"
                            }
                        }
                    },
                    new ToDoList
                    {
                        Id = Guid.NewGuid(),
                        Name = "In the yard",
                        IsComplete = false,
                        IsInProgress = false,
                        Items = new List<ToDoListItem>
                        {
                            new ToDoListItem
                            {
                                Description = "Cut the grass"
                            },
                            new ToDoListItem
                            {
                                Description = "Trim the hedges"
                            },
                            new ToDoListItem
                            {
                                Description = "Water the garden"
                            }
                        }
                    },
                };
                for (int i = 0; i < toDoList.Count; i++)
                {
                    int priorityCount = 1;
                    toDoList[i].Items.ForEach(x =>
                    {
                        x.ToDoListId = toDoList[i].Id;
                        x.IsInProgress = false;
                        x.IsComplete = false;
                        x.Priority = priorityCount++;
                    });
                }

                await context.AddRangeAsync(toDoList);
                await context.SaveChangesAsync();
            }
        }
    }
}
