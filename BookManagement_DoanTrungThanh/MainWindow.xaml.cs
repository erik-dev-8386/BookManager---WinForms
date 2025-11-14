using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
using Microsoft.IdentityModel.Tokens;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _service = new();
       
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Main Window Load
        /// <summary>
        /// Load Data đổ lên lưới 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid(); 
        }
        #endregion Main Window Load
        #region Đổ data lên lưới
        /// <summary>
        ///  Đổ data lên lưới bằng ItemsSource
        /// </summary>
        // make helper, support for other function
        private void FillDataGrid()
        {
            // ItemsSource: Đổ data lên lưới
            // BookListDataGrid là id của nguyên 1 lưới đang chuẩn bị đổ
            BookListDataGrid.ItemsSource = null;
            BookListDataGrid.ItemsSource = _service.GetAllBooks();
        }
        #endregion Đổ data lên lưới
        #region Xử lý khi người dùng bấm Create button
        /// <summary>
        /// Xử lý khi người dùng bấm nút Create button trên giao diện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Createbutton_Click(object sender, RoutedEventArgs e)
        {
            // call detail window to show display
            // Tạo cửa sổ của BookDetailWindow
            // Hiển thị cửa sổ dạng modal (phải đóng cửa sổ này mới dùng được cửa sổ khác)
            // Sau khi đóng cửa sổ → Reload lại danh sách sách trong DataGrid
            BookDetailWindow detailWindow = new BookDetailWindow();
            // ShowDialog() dùng để hiển thị một Form dưới dạng modal dialog. Tức là không tắt BookDetailWindow thì ko thao tác được bên MainWinDow
            detailWindow.ShowDialog(); // close display to can show other display
            // Tắt fill lại lưới
            FillDataGrid();
        }
        #endregion Xử lý khi người dùng bấm Create button
        #region Xử lý khi người dùng bấm Update Button
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // lấy cái dòng đang được chọn trong cái lưới đấy và ép kiểu dòng đó thành 1 đối tượng Book rồi chuẩn bị lấy đối tượng đấy gửi sang bên detailWindow xử lý
            //Lấy dòng đang chọn trong DataGrid và ép nó thành kiểu Book. Nếu không ép được, giá trị sẽ là null
            Book? selected = BookListDataGrid.SelectedItem as Book;
            // nếu null thì mở pop up lỗi
            if(selected == null)
            {
                // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                // MessageBox.Show truyền 4 tham số:
                // 1. Truyền câu mún hiển thị
                // 2. Là cái phần caption/title (tiêu đề của popup)
                // 3. Button nút nào hiển thị
                // 4. Icon nào hiển thị
                // ko chọn thì show ra câu chửi
                MessageBox.Show("Please select a book before editing", "Select one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // chạy đến đây tức là đã chọn 1 book rồi -> sau đó đẩy sang bên detai để đổ vào EditedBook
            // new cái đối tượng detailWindow
            BookDetailWindow detailWindow = new BookDetailWindow();
            // đổ book đã chọn vào edited book
            detailWindow.EditedBook = selected;
            // ShowDialog() dùng để hiển thị một Form dưới dạng modal dialog. Tức là không tắt BookDetailWindow thì ko thao tác được bên MainWinDow
            detailWindow.ShowDialog(); // close display to can show other display
            // Fill lại lưới
            FillDataGrid();
        }
        #endregion Xử lý khi người dùng bấm Update Button
        #region Xử lý khi người dùng bấm Delete button  
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // lấy cái dòng đang được chọn trong cái lưới đấy và ép kiểu dòng đó thành 1 đối tượng Book rồi chuẩn bị lấy đối tượng đấy gửi sang bên detailWindow xử lý
            //Lấy dòng đang chọn trong DataGrid và ép nó thành kiểu Book. Nếu không ép được, giá trị sẽ là null
            Book? selected = BookListDataGrid.SelectedItem as Book;
            if (selected == null)
            {
                // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
                // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
                // MessageBox.Show truyền 4 tham số:
                // 1. Truyền câu mún hiển thị
                // 2. Là cái phần caption/title (tiêu đề của popup)
                // 3. Button nút nào hiển thị
                // 4. Icon nào hiển thị
                // ko chọn thì show ra câu chửi
                MessageBox.Show("Please select a book before deleting", "Select one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // chạy đến đây tức là đã chọn 1 book rồi -> sau đó đẩy sang bên detai để đổ vào EditedBook
            // MessageBox là một popup box dùng để hiển thị thông báo cho user trong ứng dụng Windows
            // MessageBox.Show dùng để HIỂN THỊ POPUP THÔNG BÁO cho user trong ứng dụng Windows
            // MessageBox.Show truyền 4 tham số:
            // 1. Truyền câu mún hiển thị
            // 2. Là cái phần caption/title (tiêu đề của popup)
            // 3. Button nút nào hiển thị
            // 4. Icon nào hiển thị
            // hỏi có chắc xóa không
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete this book?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // nếu đáp án NO thì ko xóa
            if (answer == MessageBoxResult.No)
            { // chọn no thì không xóa nữa
                return;                
            }
            // YES thì xóa
            // xuống tới đâu là muốn xóa rồi
            _service.DeleteBook(selected);
            FillDataGrid();
        }
        #endregion Xử lý khi người dùng bấm Delete button  
        #region Xử lý khi người bấm Quit
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion Xử lý khi người bấm Quit
        #region Search
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Book> books = _service.SearchBookByFeatureName(BookNameTextBox.Text.Trim());
            if (books.IsNullOrEmpty())
            {
                MessageBox.Show("No Book found!, Try with another keyword", "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            BookListDataGrid.ItemsSource = null;
            BookListDataGrid.ItemsSource = books;
        }
        #endregion search
    }
}