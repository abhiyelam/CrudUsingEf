using CrudUsingEf.Data;
using CrudUsingEf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEf.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        CategoryDAL categoryDAL;
        public CategoryController(ApplicationDbContext db) 
        {
            this.db = db;
            this.categoryDAL=new CategoryDAL(db);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var list=categoryDAL.GetCategories();
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category=categoryDAL.GetCategoryById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result=categoryDAL.AddCategory(category);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoryDAL.GetCategoryById(id);
            return View(category);
            
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = categoryDAL.UpdateCategory(category);
                if (result == 1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category= categoryDAL.GetCategoryById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= categoryDAL.DeleteCategory(id);
                if (result == 1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
