using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL.Models;

namespace BookManagement.DAL.Repositories
{
    // flow code gui-ui - services - repo - dbcontext - table in SQL
    public class BookCateRepositories
    {
        private BookManagementDbContext _dbContext;
        #region Get All Book Categories
        /// <summary>
        /// Hàm này lấy ra tất cả các BookCategory
        /// </summary>
        /// <returns>List<BookCategory></returns>
        public List<BookCategory>  GetAll()
        {
            _dbContext = new BookManagementDbContext(); // phải luôn luôn new DBContext!!!!;
            return _dbContext.BookCategories.ToList(); // get all category
        }
        #endregion Get All Book Categories
    }
}
