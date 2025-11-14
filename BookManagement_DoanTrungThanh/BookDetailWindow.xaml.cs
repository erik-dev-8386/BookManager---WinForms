using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        // khai báo BookService
        private BookService _service = new();
        // khai báo BookCateService
        private BookCateService _cateService = new();
        // khai báo biến này để hứng data từ mainWindow qua, vì chọn 1 book để edit Book đó
        public Book EditedBook { get; set; } = null;

        public BookDetailWindow()
        {
            InitializeComponent();
        }
        #region Xử lý khi người dùng bấm nút Save Book
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Book x = new();

            //add information
            x.BookId = int.Parse(BookIdTextBox.Text); // if key auto asc, else no write this line
            x.BookName = BookNameTextBox.Text;
            x.Description = DescriptionTextBox.Text;
            x.PublicationDate = DateTime.Parse(PublicationDateDatePicker.Text);
            x.Quantity = int.Parse(QuantityTextBox.Text);
            x.Price = double.Parse(PriceTextBox.Text);
            x.Author = AuthorTextBox.Text;
            x.BookCategoryId = int.Parse(BookCategoryIdComboBox.SelectedValue.ToString()); // phải ToString() và xem nó là kiểm dữ liệu gì và phải ép kiểu theo kiểu dữ liệu của nó... ví dụ kiểu int thì parse theo kiểu int, double thì parse theo kiểu double

            // Kiểm tra xem  bên mainWindow có truyền đối tượng qua không?
            // Nếu không truyền  -> EditedBook == null -> Tạo mới 1 cuốn sách
            // Nếu truyền -> EditedBook != null -> Sửa cuốn sách đã có trong databse
            if(EditedBook == null)
            {
                _service.AddBook(x);
            }else
            {
                _service.UpdateBook(x);
            }
            //close display
            this.Close();
        }
        #endregion Xử lý khi người dùng bấm nút Save Book
        #region Load Window
        /// <summary>
        /// Hàm này sẽ chạy đầu tiên để load data và fill combobox, và fill thông tin cuốn sách đang muốn edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EditedBook);

            //FILL CÁI NHÃN CHO RÕ ĐỂ BIẾT KHI NÀO CREATE KHI NÀO UPDATE
            if(EditedBook == null)
            {
                // DetailWindowModeLabel này là cái nhãn trên giao diện
                DetailWindowModeLabel.Content = "Create book information";
            }else
            {
                // DetailWindowModeLabel này là cái nhãn trên giao diện
                DetailWindowModeLabel.Content = "Update book information";
            }
        }
        #endregion Load Window
        #region Đổ data khóa ngoại lên combobox
        // write function to fill data into BookCategoryIdComboBox
        /// <summary>
        /// Hàm này để đổ data lên cái combobox(sổ thông tin tham chiếu cho người dùng chọn)
        /// </summary>
        private void FillComboBox()
        {
            // Đổ data lên combobox
            // BookCategoryIdComboBox id của combobox đó ở trên giao diện
            // ItemsSource dùng để:
            // 1. Binding danh sách data vào ComboBox
            // 2. Khi user click vào ComboBox → hiện ra list để chọn
            // 3. Giống như dropdown list trong web HTML<select>
            // => Binding dữ liệu (load data vào combobox)
            BookCategoryIdComboBox.ItemsSource = _cateService.GetAllCategories();
            // DisplayMemberPath dùng để chỉ định property nào của object sẽ được HIỂN THỊ trong ComboBox
            // ==> DisplayMemberPath là để giao diện khi người dùng sổ combobox nó hiện cái gì
            BookCategoryIdComboBox.DisplayMemberPath = "BookGenreType";
            // SelectedValuePath dùng để chỉ định property nào của object sẽ được LẤY GIÁ TRỊ khi user chọn item trong ComboBox
            // ==> SelectedValuePath là khi người dùng chọn 1 thông tin combobox nó sẽ lấy cái này truyền xuống DB xử lý
            // khi đã chọn BookGenreType thì sẽ lấy value(id) của BookGenreType đó để truyền về DB
            // khi user chọn cột, thì value(id) của BookGenreType sẽ đưuọc đổ vào select value
            BookCategoryIdComboBox.SelectedValuePath = "BookCategoryId";
        }
        #endregion Đổ data khóa ngoại lên combobox
        #region Đổ data thông tin của 1 cuốn sách khi edit
        /// <summary>
        /// Hàm này dùng để khi bên MainWindow có truyền đối tượng EditedBook qua bên này (EditedBook != null) thì ta lấy thông tin sách đó đổ lên những control/input lên giao diện
        /// </summary>
        /// <param name="x"></param>
        private void FillElement(Book x) // đổ data vào các ô nhập, khi edit
        {
            if (x == null)
            {
                return;
            }
            // khác null mới cho phép đổ data vào để edit
            // BookIdTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            BookIdTextBox.Text = x.BookId.ToString();
            //disable id ĐỂ KO CHO EDIT ID
            // IsEnabled: Không cho đổi id khi edit
            BookIdTextBox.IsEnabled = false;
            // BookNameTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            BookNameTextBox.Text = x.BookName;
            // BookNameTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            DescriptionTextBox.Text = x.Description;
            // PublicationDateDatePicker là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            PublicationDateDatePicker.Text = EditedBook.PublicationDate.ToString();// ngày tháng năm trong cuốn sách là kiểu DateTime
            // .Text của cái element DateTimePicker cần text ta đổi sang text để gán vào
            // QuantityTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            QuantityTextBox.Text = x.Quantity.ToString();
            // PriceTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            PriceTextBox.Text = x.Price.ToString();
            // AuthorTextBox là Id của ô TextBox ID trên giao diện
            // Text là để đổ data lên cái ô TextBox đó
            AuthorTextBox.Text = x.Author.ToString();
            // BookCategoryIdComboBox là Id của ô Combobox ID trên giao diện
            // SelectedValue để đổ lên thì chọn đúng cái khóa đang lưu ở database
            //nhảy đúng id
            BookCategoryIdComboBox.SelectedValue = x.BookCategoryId;
        }
        #endregion Đổ data thông tin của 1 cuốn sách khi edit
        #region Xử lý khi user bấm Close Button
        /// <summary>
        /// Xử lý khi người dùng bấm Close Button trên giao diện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion Xử lý khi user bấm Close Button
    }
}
