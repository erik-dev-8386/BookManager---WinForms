# 📚 Book Management – WinForms Application

## 📝 Giới thiệu
**Book Management** là ứng dụng WinForms giúp quản lý sách.  
Ứng dụng hỗ trợ đăng nhập, quản lý danh sách sách và tải danh mục sách lên lưới.
---

## 🔧 Công nghệ sử dụng
- C# .NET WinForms  
- SQL Server  
- Entity Framework và LINQ
- Kiến trúc: GUI – BLL – DAL  

---

## 🚀 Chức năng chính

### 🔐 1. Đăng nhập (Login)
- Kiểm tra username và password từ database  
- Thông báo khi nhập sai  
- Chỉ cho phép vào hệ thống khi đăng nhập hợp lệ  

### 📘 2. Quản lý Sách (Book CRUD)
- **Create:** Thêm sách mới  
- **Read:** Xem danh sách sách  
- **Update:** Chỉnh sửa sách  
- **Delete:** Xóa sách  
- Hỗ trợ tìm kiếm theo tên sách

### 🏷 3. Danh mục Sách (Book Category)
- Load toàn bộ Category lên ComboBox  
- Gắn Category vào Book khi thêm/sửa  
- Hiển thị Category trong bảng dữ liệu  

---
