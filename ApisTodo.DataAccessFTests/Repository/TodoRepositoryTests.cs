using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApisTodo.DataAccessF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApisTodo.ModelsF;

namespace ApisTodo.DataAccessF.Repository.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        private ApisTodoEntity context;
        private ITodoRepository todoRepository;

        [TestInitialize() ]
        public void TodoRepositoryTest()
        {
            context = new ApisTodoEntity();
            todoRepository = new TodoRepository(context);
        }

        [TestMethod()]
        public async Task TodoRepository_Add()
        {
            TodoItem todoItem = new TodoItem
            {
                TodoTitle = "Pay Electricity Bill",
                TodoDescrption = "Need to Pay the Electricity Bill"
            };

            var entity = await todoRepository.Add(todoItem);

            Assert.AreEqual(todoItem, entity);
        }


        [TestMethod()]
        public async Task TodoRepository_Delete()
        {
            var result = await todoRepository.Get();
            var todoitem = result.First();

            var deleteResult = await todoRepository.Delete(todoitem.TodoId);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod()]
        public async Task TodoRepository_Update()
        {
            var result = await todoRepository.Get();
            var todoitem = result.First();

            todoitem.TodoTitle = "Pay Mobile Bill";

            var updateResult =await todoRepository.Update(todoitem);

            Assert.IsTrue(updateResult);
        }

        [TestMethod()]
        public async Task TodoRepository_GetById()
        {
            var result = await todoRepository.Get();
            var todoitem = result.First();

            var item = await todoRepository.GetById(todoitem.TodoId);

            Assert.AreEqual(item.TodoId, todoitem.TodoId);
        }
    }
}