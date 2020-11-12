using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);
        Task<bool> AddItemAsync(TodoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}