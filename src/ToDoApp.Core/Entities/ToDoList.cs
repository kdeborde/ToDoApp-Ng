namespace ToDoApp.Core.Entities
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation property
        public List<ToDoListItem> Items { get; set; } = [];
    }
}
