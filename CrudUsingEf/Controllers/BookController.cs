using CrudUsingEf.Data;
using CrudUsingEf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEf.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;
        BookDAL bookDAL;
        public BookController(ApplicationDbContext db) 
        { 
            this.db = db;
               this.bookDAL=new BookDAL(db);
        }

        // GET: BookController
        public ActionResult Index()
        {
            var list=bookDAL.GetBooks();
            return View(list);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book=bookDAL.GetBookById(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result=bookDAL.AddBook(book);
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookDAL.GetBookById(id);
            return View(book);

            //return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result=bookDAL.UpdateBook(book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookDAL.GetBookById(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result=bookDAL.DeleteBook(id);
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
