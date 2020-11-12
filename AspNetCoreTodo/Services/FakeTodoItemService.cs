using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        private readonly List<TodoItem> _database;

        public FakeTodoItemService()
        {
            _database = new List<TodoItem> {
                new TodoItem {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1),
                    Id = Guid.NewGuid()
                },
                new TodoItem {
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2),
                    Id = Guid.NewGuid()
                }
            };
        }

        public Task<bool> AddItemAsync(TodoItem newItem) => Task.FromResult<bool>(AddItem());
        
        private bool AddItem()
        {
            _database.Add(new TodoItem {
                Title = "Continue learning ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(2),
                Id = Guid.NewGuid()
            });
            return true;
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync()
            => Task.FromResult(
                _database.ToArray()
            );

        public Task<bool> MarkDoneAsync(Guid id)
        {
            var item = _database.SingleOrDefault(x => x.Id == id);
            if(item == null) return Task.FromResult(false);
            item.IsDone = true;
            return Task.FromResult(true);
        }
    }
}