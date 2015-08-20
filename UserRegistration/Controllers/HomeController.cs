using System.Linq;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class HomeController : AsyncController
    {
        private UserDbContext db = new UserDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewUsers()
        {
            return View("ViewUsers", db.Users.ToList());
        }
        public ActionResult CreateUserCompleted()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void CreateUserAsync(User user)
        {
            if (ModelState.IsValid)
            {
                AsyncManager.OutstandingOperations.Increment();
                db.Users.Add(user);
                db.SaveChanges();
                AsyncManager.OutstandingOperations.Decrement();
            }
        }
    }
}