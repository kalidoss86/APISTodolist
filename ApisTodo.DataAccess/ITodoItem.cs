using System;
using System.Collections.Generic;
using System.Text;

namespace ApisTodo.DataAccess
{
    public interface ITodoItem : IBaseRepository<Models.TodoItem>
    {
    }
}
