using Microsoft.AspNetCore.Identity;

namespace IdentityTodoList.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<TodoItem>? TodoItems { get; set; } = new();
    }
}
