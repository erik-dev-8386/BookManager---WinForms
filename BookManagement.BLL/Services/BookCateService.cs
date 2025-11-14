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
    public class BookCateService
    {
        // khai bao trc khi sai
        private BookCateRepositories _repo = new();

        //function get all category
        public List<BookCategory> GetAllCategories()
        {
            return _repo.GetAll();
        }
    }
}
