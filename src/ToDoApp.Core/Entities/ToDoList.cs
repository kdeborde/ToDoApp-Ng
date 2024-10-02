namespace ToDoApp.Core.Entities
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ToDoListItem> Items { get; set; } = [];
    }
}
