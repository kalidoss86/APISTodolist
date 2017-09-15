using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApisTodo.DataAccessF.Repository;
using ApisTodo.DataAccessF;
using System.Threading.Tasks;
using ApisTodo.ModelsF;
using System.Web.Http;

namespace TodoMVCAng.Controllers
{
  [Route("api/[controller]")]
  public class HomeController : Controller
  {
    ApisTodo.ModelsF.ApisTodoEntity context = new ApisTodo.ModelsF.ApisTodoEntity();
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    [System.Web.Mvc.HttpPost]
    [Route("AddTask/{task}")]
    public async Task<JsonResult> AddTask([FromBody]string task)
    {
      ITodoRepository _todoRepository = new TodoRepository(context);


      var todoItem = await _todoRepository.Add(new TodoItem
      {
        TodoTitle = task,
        TodoDescrption = task,
        CreateTime = DateTime.Now,
        UpdateTime = DateTime.Now
      });

      return Json(todoItem, JsonRequestBehavior.AllowGet);
    }

    [System.Web.Mvc.HttpGet]
    [Route("GetTodoList")]
    public async Task<JsonResult> GetTodoList()
    {
      ITodoRepository _todoRepository = new TodoRepository(context);

      var todoList = await _todoRepository.Get();

      
      return Json(todoList, JsonRequestBehavior.AllowGet);
    }
  }
}
