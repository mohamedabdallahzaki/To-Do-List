using Microsoft.AspNetCore.Mvc;
using Task.Models.Context;
using Task.Models.Entites;

namespace Task.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IContext _context ;

        public ToDoListController(IContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
            return View(_context.Items);
        }


        [HttpGet]

        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddItem (Item item)
        {
            
             _context.AddItem(item);
              return  RedirectToAction("Index");
           

        }

        [HttpPost]

        public IActionResult Delete (int Id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == Id);
            if(item != null)
            {
                _context.DeleteItem(Id);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult ChangeStatues (int Id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == Id);

            if(item != null)
            {
                item.IsCompleted = !item.IsCompleted;
            }

            return RedirectToAction("index");

        }




    }
}
