using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DAL.Models;

namespace BookManagement.DAL.Repositories
{

    
    public class UserRepository
    {
        private BookManagementDbContext _context;
        #region Login
        /// <summary>
        /// Hàm này để lấy thực hiện chức năng login vào hệ thống
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>UserAccount?</returns>
        public UserAccount? GetOne(string email, string password)
        {
            // new context ở chỗ xài
            // phải luôn luôn new DBContext!!!!;
            _context = new();
            // nó là 1 cái hàm for each
            // trả về null
            // hàm FirstorDefault có thể trả về hoặc 1 Account tìm thấy, hoặc null, ta thêm dấu ? để cho phép nó null và để tránh warning
            // hàm nhận vào biểu thức lambda, là cái hàm cx xài =>
            // DELIGATE !!!!!!
            // x chính là biến userAccount là forEach
            return _context.UserAccounts.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            // ToLower(); so sánh chuỗi nhưng mà password chữ hoa chữ thường thì....
            // còn password thì ko cần....
            // CHUỖI TRONG JAVA MÚN  SO SÁNH PHẢI CHẤM TÊN HÀM
            // String name1 = "...", name2 = "...";
            // name1.equals(name2)
            // VÌ CHUỖI LÀ OBJECT, SO SÁNH 2 BIẾN OBJECT KO ĐC DÙNG  == VÌ LÀ SO SÁNH 2 TỌA ĐỘ
            // VỚI C# SO SÁNH CHUỖI DÙNG DẤU == LUÔN !!!
            // VÌ C# ĐÃ ĐỘ LẠI == DÀNH RIÊNG CHO PRIMITIVE NAY DÙNG ĐỂ SO SÁNH OBJECT STRING LUÔN!!!!!!!!!!!!!!

        }
        #endregion Login
    }
}
