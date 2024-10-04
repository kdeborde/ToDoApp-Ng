namespace ToDoApp.Core.Entities
{
    public class ToDoListItem
    {
        public Guid Id { get; set; }
        public Guid ToDoListId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsInProgress { get; set; } = false;
        public bool IsComplete { get; set; } = false;
        public int Priority { get; set; }
    }
}
