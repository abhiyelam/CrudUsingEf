using CrudUsingEf.Data;

namespace CrudUsingEf.Models
{
    public class CategoryDAL
    {
        private readonly ApplicationDbContext db;
        public CategoryDAL(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetCategories() 
        {
            return db.Categories.ToList();
            
        }
        public Category GetCategoryById(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }
        public int AddCategory(Category category)
        {
            db.Categories.Add(category);
            int result=db.SaveChanges();
            return result;
        }
        public int UpdateCategory(Category category)
        {
            int result = 0;
            var p = db.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = category.Name;
                
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            var p=db.Categories.Where(x => x.Id==id).FirstOrDefault();
            if (p != null)
            {
                db.Categories.Remove(p);
                result=db.SaveChanges();
            }
            return result;
        }
    }
}
