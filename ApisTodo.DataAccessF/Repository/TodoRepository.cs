using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApisTodo.ModelsF;

namespace ApisTodo.DataAccessF.Repository
{
    public class TodoRepository : BaseRepository<ApisTodo.ModelsF.TodoItem>, ITodoRepository
    {
        public TodoRepository(ApisTodoEntity _apisTodoEntity) : base(_apisTodoEntity)
        {
        }
    }
}
