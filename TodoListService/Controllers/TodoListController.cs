using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TodoListService.Data;
using TodoListService.Models;

namespace TodoListService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        static ConcurrentBag<TodoItem> todoStore = new ConcurrentBag<TodoItem>();
        private TodoContext _context;

        public TodoListController(TodoContext context)
        {
            _context = context;

        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            string owner = (User.FindFirst(ClaimTypes.NameIdentifier))?.Value;
            //TODO make async
            return _context.TodoItems.Where(t => t.Owner == owner).ToList();
            //return todoStore.Where(t => t.Owner == owner).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoItem Todo)
        {
            string owner = (User.FindFirst(ClaimTypes.NameIdentifier))?.Value;
            _context.TodoItems.Add(new TodoItem { Owner = owner, Title = Todo.Title });
            //TODO make async
            _context.SaveChanges();
            //todoStore.Add(new TodoItem { Owner = owner, Title = Todo.Title });
        }
    }
}
