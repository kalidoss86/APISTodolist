﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApisTodo.DataAccessF
{
    public interface ITodoRepository : IBaseRepository<ModelsF.TodoItem>
    {
    }
}
