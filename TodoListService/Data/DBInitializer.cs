using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListService.Models;

namespace TodoListService.Data
{
    public class DBInitializer
    {
        public static void Initialize(TodoContext context)
        {
            context.Database.EnsureCreated();

            if (context.TodoItems.Any())
            {
                return; //db has been seeded
            }

            
        }
    }
}
