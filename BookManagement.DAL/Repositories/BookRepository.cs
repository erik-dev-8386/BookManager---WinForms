using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories
{
    // flow code gui/ui - services - repo - dbcontext - table in SQL
    public class BookRepository
    {
        private BookManagementDbContext _dbContext;
        #region GetAll
        /// <summary>
        /// Hàm này lấy ra tất cả danh sách các sách
        /// </summary>
        /// <returns>List<Book></returns>
        public List<Book> GetAll()
        {
            // phải luôn luôn new DBContext!!!!;
            _dbContext = new();
            //return _dbContext.Books.ToList();  này không lấy được khóa ngoại để show danh sách
            return _dbContext.Books.Include("BookCategory").ToList();// Dùng include để lấy khóa ngoại show lên danh sách
        }
        #endregion GetAll
        #region Add Book
        /// <summary>
        /// Hàm này để thêm 1 sách vào database
        /// </summary>
        /// <param name="x"></param>
        public void Add(Book x) {
            // phải luôn luôn new DBContext!!!!;
            _dbContext = new(); 
            _dbContext.Books.Add(x);// Mới lưu ở RAM chưa lưu ở DB
            _dbContext.SaveChanges();// really save in DB 
        }
        #endregion Add Book
        #region Update Book
        /// <summary>
        /// Hàm này để chỉnh sửa/update thông tin sách đã có trong database
        /// </summary>
        /// <param name="x"></param>
        public void Update(Book x)
        {
            // phải luôn luôn new DBContext!!!!;
            _dbContext = new();
            _dbContext.Books.Update(x);// Mới lưu ở RAM chưa lưu ở DB
            _dbContext.SaveChanges();// really save in DB 
        }
        #endregion Update Book
        #region Delete Book
        /// <summary>
        /// Hàm này để xóa 1 cuốn sách trong database
        /// </summary>
        /// <param name="x"></param>
        public void Delete(Book x)
        {
            // phải luôn luôn new DBContext!!!!;
            _dbContext = new(); 
            _dbContext.Books.Remove(x);// Mới lưu ở RAM chưa lưu ở DB
            _dbContext.SaveChanges();// really save in DB 
        }
        #endregion Delete Book
        #region Search Book By Name
        /// <summary>
        /// Hàm này để search gần đúng các cuốn sách có trong database có chứa từ khóa truyền vào
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>List<Book></Book></returns>
        public List<Book> SearchByNameOrDesc(String keyword)
        {
            // mặc định trả về hết, nếu có keyword thì filter
            List<Book> books = GetAll();
            if (keyword != null)
            {
                //có keyword ta filter tiếp trên books
                //books đang chứa hết, giờ lọc thêm theo keyword
                //books.Where(một biểu thức lambda,trong biểu thức lambda thì x là Book, và mình trả về sách có thoả dk lọc hay ko);
                //books.Where(x => ???); //check xem x, chính là 1 cuốn trong list, có thoả đk filter ko
                //books.Where(x => x.BookName == Keyword || x.Description == Keyword).ToList();

                return books.Where(x => x.BookName.ToLower().Contains(keyword.ToLower()) || x.Description.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return books;//return tất nếu có keyword 
        }
        #endregion Search Book By Name
    }
}
