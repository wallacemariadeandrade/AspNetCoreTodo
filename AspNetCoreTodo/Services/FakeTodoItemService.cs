using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

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

        public Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user) 
            => Task.FromResult<bool>(AddItem(user.Id));
        
        private bool AddItem(string userId)
        {
            _database.Add(new TodoItem {
                Title = "Continue learning ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(2),
                Id = Guid.NewGuid(),
                UserId = userId
            });
            return true;
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user)
            => Task.FromResult(
                _database.Where(x => x.UserId == user.Id).ToArray()
            );

        public Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var item = _database.SingleOrDefault(x => x.Id == id && x.UserId == user.Id);
            if(item == null) return Task.FromResult(false);
            item.IsDone = true;
            return Task.FromResult(true);
        }
    }
}