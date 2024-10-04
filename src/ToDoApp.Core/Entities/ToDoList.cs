namespace ToDoApp.Core.Entities
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsInProgress { get; set; } = false;
        public bool IsComplete { get; set; } = false;

        // Navigation property
        public List<ToDoListItem> Items { get; set; } = [];
    }
}
