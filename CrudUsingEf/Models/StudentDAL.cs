using CrudUsingEf.Data;

namespace CrudUsingEf.Models
{
    public class StudentDAL
    {

        private readonly ApplicationDbContext db;
        public StudentDAL(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public IEnumerable<Student> GetAllStudent() 
        {
            return db.Students.ToList();
        }
        public Student GetStudentById(int id)
        {
            var result = db.Students.Find(id);
            return result;
        }
        public int AddStudent(Student student)
        {
            db.Students.Add(student);
            int result=db.SaveChanges();  
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int result = 0;
            var p=db.Students.Where(x=>x.Id==student.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name= student.Name;
                p.Mobileno = student.Mobileno;
                p.Email= student.Email;
               p.Percentage= student.Percentage;
                result = db.SaveChanges();
            }
             return result;
        }
        public int DeleteStudent(int id) 
        {
            int result = 0;
            var p=db.Students.Where(x=>x.Id==id).FirstOrDefault();
            if (p != null)
            {
                db.Students.Remove(p);
               result =db.SaveChanges();
            }
            return result;
        }

    }
}
