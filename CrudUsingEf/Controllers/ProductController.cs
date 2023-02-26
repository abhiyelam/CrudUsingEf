using CrudUsingEf.Data;
using CrudUsingEf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEf.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
             ProductDAL productDAL;
        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
            this.productDAL =  new ProductDAL(db);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var list=productDAL.GetAllProducts();
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product=productDAL.GetProductById(id);  
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result=productDAL.AddProduct(product);
                if(result==1) 
                 return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product= productDAL.GetProductById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result=productDAL.UpdateProduct(product);
                if(result==1)
                return RedirectToAction(nameof(Index));
                else 
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productDAL.GetProductById(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= productDAL.DeleteProduct(id);
                if(result==1)
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
