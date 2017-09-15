using ApisTodo.DataAccessF.Repository;
using ApisTodo.ModelsF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;
using ApisTodo.DataAccessF;
//using Microsoft.IdentityModel.Tokens;

namespace ApisTodo
{
    class Program
    {
        static void Main(string[] args)
        {


            TestAsync();

            //ApisTodoEntity apisTodoEntity = new ApisTodoEntity(options=> options)
            //BaseRepository<TodoItem> baseRepository = new BaseRepository<TodoItem>()
        }

        private async static void TestAsync()
        {
            ApisTodoEntity context = new ApisTodoEntity();

            ITodoRepository todoRepository = new TodoRepository(context);



            var t = await todoRepository.Add(new TodoItem
            {
                TodoTitle = "My First Todo",
                TodoDescrption = "Hello Todo",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            });
        }
    }
}
