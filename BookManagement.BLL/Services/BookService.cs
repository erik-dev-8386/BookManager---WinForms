using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;

namespace BookManagement.BLL.Services
{
    // flow code gui-ui - services - repo - dbcontext - table in SQL
    public class BookService
    {
        // init value
        private BookRepository _repo = new();
        #region Get All Book
        /// <summary>
        /// Get All Book 
        /// </summary>
        /// <returns></returns>
        //function Get all list book
        public List<Book> GetAllBooks()
        {
            return _repo.GetAll();
        }
        #endregion Get All Book
        #region Add Book
        /// <summary>
        /// Add Book
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            _repo.Add(book);
        }
        #endregion Add Book
        #region Update Book
        /// <summary>
        /// Update thông tin 1 sách có trong database
        /// </summary>
        /// <param name="book"></param>
        public void UpdateBook(Book book)
        { 
            _repo.Update(book);

        }
        #endregion Update Book
        #region Delete Book
        /// <summary>
        /// Delete 1 Book trong Database
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(Book book)
        {
            _repo.Delete(book);
        }
        #endregion Delete Book
        #region Search Book By Name
        /// <summary>
        /// Hàm này để search sách trong database với featureName truyền vào
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns></returns>
        public List<Book> SearchBookByFeatureName(string featureName)
        {
            return _repo.SearchByNameOrDesc(featureName);
        }
        #endregion Search Book By Name
    }
}
