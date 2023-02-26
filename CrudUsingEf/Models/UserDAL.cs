using CrudUsingEf.Data;

namespace CrudUsingEf.Models
{
    public class UserDAL
    {
        private readonly ApplicationDbContext db;

        public UserDAL(ApplicationDbContext db) 
        { 
            this.db = db;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }
        public int AddUser(User user) 
        { 
            db.Users.Add(user);
            int result=db.SaveChanges();
            return result;
        }
    }
}
