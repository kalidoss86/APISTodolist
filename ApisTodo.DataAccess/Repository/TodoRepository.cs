using System;
using System.Collections.Generic;
using System.Text;
using ApisTodo.Models;

namespace ApisTodo.DataAccess.Repository
{
    public class TodoRepository : BaseRepository<Models.TodoItem>, ITodoItem
    {
        public TodoRepository(ApisTodoEntityCore todoEntity) : base(todoEntity)
        {
        }
    }
}
