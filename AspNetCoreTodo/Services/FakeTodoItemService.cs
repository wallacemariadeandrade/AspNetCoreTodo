using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<bool> AddItemAsync(TodoItem newItem) => Task.FromResult<bool>(true);
        
        public Task<TodoItem[]> GetIncompleteItemsAsync()
            => Task.FromResult(
                new[]{
                    new TodoItem {
                        Title = "Learn ASP.NET Core",
                        DueAt = DateTimeOffset.Now.AddDays(1)
                    },
                    new TodoItem {
                        Title = "Build awesome apps",
                        DueAt = DateTimeOffset.Now.AddDays(2)
                    }
                }
            );
    }
}