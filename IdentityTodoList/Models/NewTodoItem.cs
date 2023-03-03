namespace IdentityTodoList.Models
{
    public class NewTodoItem
    {
        public string Title { get; set; } = string.Empty;


        public List<TodoItem>? TodoItems { get; set; } = new();
    }
}
