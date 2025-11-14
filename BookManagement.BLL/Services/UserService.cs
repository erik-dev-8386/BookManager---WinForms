using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;

namespace BookManagement.BLL.Services
{
    public class UserService
    {
        private UserRepository _userRepository = new();
        public UserAccount? Authenticate(string email, string password)
        {
            return _userRepository.GetOne(email, password);
        }
    }
}
