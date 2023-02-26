using CrudUsingEf.Data;
using CrudUsingEf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEf.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;
        UserDAL userDAL;
        public UserController(ApplicationDbContext db)
        {
            this.db = db;
            this.userDAL = new UserDAL(db);
        }

        // GET: UserController
        public ActionResult Index()
        {
            var list = userDAL.GetAllUsers();
            return View(list);
        }

        
       

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                int result = userDAL.AddUser(user);
                if (result == 1)
                return RedirectToAction(nameof(Index));
                
                //return View(result); 

                // return View("Create",new User());

                else
                    return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var isValid = db.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
            if (isValid != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            return View();
        }
    }
}

        
        