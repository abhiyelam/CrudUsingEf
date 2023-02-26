using CrudUsingEf.Data;

namespace CrudUsingEf.Models
{
    public class BookDAL
    {
        private readonly ApplicationDbContext db;
        public BookDAL(ApplicationDbContext db) 
        { 
            this.db = db;
        }  
        public IEnumerable<Book> GetBooks()
        {
            return db.Books.ToList();
        }
        public Book GetBookById(int id) 
        {
            var book = db.Books.Find(id);
            return book;
        }
        public int AddBook(Book book)
        {
             db.Books.Add(book);
            int result=db.SaveChanges();
            return result;
        }
        public int UpdateBook(Book book)
        {
            int result = 0;
            var p=db.Books.Where(x=>x.Id==book.Id).FirstOrDefault();
            if (p!=null)
            {
                p.Name = book.Name;
                p.Price = book.Price;
                result= db.SaveChanges();
            }
            return result;
        }
        public int DeleteBook(int id)
        {
            int result = 0;
                var p=db.Books.Where(x=>x.Id==id).FirstOrDefault();
            if (p!=null)
            {
                db.Books.Remove(p);
                result=db.SaveChanges();
            }
            return result;
        }
    }
}
