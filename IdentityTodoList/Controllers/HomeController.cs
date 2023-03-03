using IdentityTodoList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IdentityTodoList.Controllers
{
    public class HomeController : Controller
    {
        string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var vm = new NewTodoItem()
            {
                TodoItems = _db.TodoItems
                    .Where(x => x.AuthorId == UserId)
                    .OrderBy(x => x.Done).ToList()
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(NewTodoItem vm)
        {
            if (ModelState.IsValid)
            {
                var todoItem = new TodoItem()
                {
                    Title = vm.Title,
                    AuthorId = UserId
                };
                _db.Add(todoItem);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            vm.TodoItems = _db.TodoItems
                .Where(x => x.AuthorId == UserId)
                .OrderBy(x => x.Done).ToList();
            return View(vm);
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SwapDone(int id)
        {
            var todoItem = _db.TodoItems.Find(id);

            if (todoItem == null)
                return NotFound();

            if (todoItem.AuthorId != UserId)
                return Unauthorized();

            todoItem.Done = !todoItem.Done;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var todoItem = _db.TodoItems.Find(id);

            if (todoItem == null)
                return NotFound();

            if (todoItem.AuthorId != UserId)
                return Unauthorized();

            _db.Remove(todoItem);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}