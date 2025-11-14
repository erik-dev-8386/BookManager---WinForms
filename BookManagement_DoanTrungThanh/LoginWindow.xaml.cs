using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookManagement.BLL.Services;
using BookManagement.DAL.Models;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private UserService _userService = new();
        #region Xử lý khi người dùng  bấm nút login
        /// <summary>
        /// Xử lý khi người dùng  bấm nút login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            {
                // ko nhập user và pass, thiếu 1 trong 2 chửi trước cái đã
                string email = EmailTextBox.Text.Trim();
                string password = PasswordTextBox.Text.Trim();
                // IsNullOrWhiteSpace là method của dùng để kiểm tra chuỗi có rỗng/null/chỉ toàn khoảng trắng hay không.
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                    // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                    // MessageBox.Show truyền 4 tham số:
                    // 1. Truyền câu mún hiển thị
                    // 2. Là cái phần caption/title (tiêu đề của popup)
                    // 3. Button nút nào hiển thị
                    // 4. Icon nào hiển thị
                    MessageBox.Show("Both email and passworđ are required!", "Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // khai báo 1 biến UserAccount để hứng từ DB
                UserAccount? account = _userService.Authenticate(email, password);

                if (account == null)
                {
                    // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                    // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                    // MessageBox.Show truyền 4 tham số:
                    // 1. Truyền câu mún hiển thị
                    // 2. Là cái phần caption/title (tiêu đề của popup)
                    // 3. Button nút nào hiển thị
                    // 4. Icon nào hiển thị
                    // select ko có thằng nào == email và pass, login sai chắc luôn
                    MessageBox.Show("Invalid email or password!", "Input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // login thành công, có account, check role tiếp
                if (account.Role == 3) //MEMBER thì ko cho vào APP này
                {
                    // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                    // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                    // MessageBox.Show truyền 4 tham số:
                    // 1. Truyền câu mún hiển thị
                    // 2. Là cái phần caption/title (tiêu đề của popup)
                    // 3. Button nút nào hiển thị
                    // 4. Icon nào hiển thị
                    MessageBox.Show("You have no permission to access the app!", "Wrong permission", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // admin, staff, manager vào, tùy bài
                else
                {
                    MainWindow main = new();
                    // TRƯỚC KHI MỞ MÀN HÌNH MAIN, CHỦ ĐỘNG DISABLE NÚT BẤM VÌ STAFF ÍT QUYỀN, KO CHO XÓA, SỬA, TẠO MỚI
                    if (account.Role == 2 || account.Role == 1) // bằng 1 Active thì cho vào
                    {
                        if (account.Role == 2)
                        {
                            // cấm nút bấm create, update, delete bên cửa sổ Main
                            // mấy nút bấm là property của cửa sổ, của class cửa sổ
                            // vậy cửa sổ. chấm prop là sờ được nút bấm = code
                            // sờ được thì ta disable (nút bấm lại tiếp tục là object, chấm nó để set thuộc tính cho nút bấm!!!!!)
                            main.Createbutton.IsEnabled = false;
                            // IsEnable  cho phép tiếp tục hay ko
                            main.UpdateButton.IsEnabled = false;
                            main.DeleteButton.IsEnabled = false;
                        }
                        this.Hide(); // ẩn login và show Main
                        main.Show();
                        return;
                    }
                    // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                    // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                    // MessageBox.Show truyền 4 tham số:
                    // 1. Truyền câu mún hiển thị
                    // 2. Là cái phần caption/title (tiêu đề của popup)
                    // 3. Button nút nào hiển thị
                    // 4. Icon nào hiển thị
                    MessageBox.Show("Inactive account can not login!", "Inactive warning", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }
        #endregion Xử lý khi người dùng bấm nút login
        #region Xử lý khi người dùng bấm quit
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion Xử lý khi người dùng bấm quit
    }
}
