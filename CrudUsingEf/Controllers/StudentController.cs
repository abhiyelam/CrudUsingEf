using CrudUsingEf.Data;
using CrudUsingEf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingEf.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext db;
        StudentDAL studentDAL;
        public StudentController(ApplicationDbContext db) 
        { 
            this.db = db;
            this.studentDAL=new StudentDAL(db);
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var list=studentDAL.GetAllStudent();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        { 
            var student = studentDAL.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result=studentDAL.AddStudent(student);
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

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentDAL.GetStudentById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result =studentDAL.UpdateStudent(student);
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentDAL.GetStudentById(id);
            return View(student);
           // return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Delete))]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result=studentDAL.DeleteStudent(id);
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
