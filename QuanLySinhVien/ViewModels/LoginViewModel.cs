using QuanLySinhVien.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySinhVien.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //Gom nhóm các thuộc tính trong lớp LoginViewModel
        #region Property
        //Thuộc tính TaiKhoan binding lên txbTaikhoan để lấy thông tin tên đăng nhập của người dùng đã nhập
        public string TaiKhoan { get; set; }
        //Thuộc tính MatKhau để lấy mật khẩu của người dùng đã nhập thông qua Command PasswordChangedCommand
        public string MatKhau { get; set; }

        //Khai báo command đăng nhập binding lên btnLogin
        public ICommand LoginCommand { get; set; }

        //Khai báo command thoát binding lên btnExit
        public ICommand ExitCommand { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbPassword 
        public ICommand PasswordChangedCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            //Command thoát sẽ thực hiện chức năng đăng nhập khi nhấn nút btnExit
            ExitCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) => p.Close());

            //Command bắt sự kiện PasswordChanged ở pwbPassword khi người dùng nhập mật khẩu ở pwbPassword
            //CommandParameter truyền vào là pwbPassword để lấy mật khẩu lưu vào thuộc tính MatKhau
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                MatKhau = p.Password;
            });

            //Command login sẽ thực hiện chức năng đăng nhập khi nhấn nút btnLogin
            LoginCommand = new RelayCommand<Window>((p) =>
            {
                //Command sẽ thực hiện nếu giá trị thuộc tính TaiKhoan và MatKhau khác null
                return TaiKhoan != null && MatKhau != null;
            }, (p) =>
            {
                QLSVDataContext db = new QLSVDataContext();
                //Câu lệnh truy vấn Linq lấy dữ liệu từ bảng TaiKhoan 
                //Với điều kiện tên tài khoản và mật khẩu phải có trên database
                var account = db.TaiKhoans.Where(tk => tk.TenTK == TaiKhoan && tk.MatKhau == MatKhau);
                //Kiểm tra biến account nếu tồn tại 1 phần tử trong account
                if (account.Count() == 1)
                {
                    //Truyền tham số TaiKhoan vào ManagerViewModel và đóng window LoginView
                    //Thông qua CommandParameter được truyền vào là loginView
                    _ = new ManagerViewModel(TaiKhoan);
                    p.Close();
                }
                else
                {
                    //Nếu trong biến account không có phần tử nào thì thông báo qua MessageBox
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng");
                }
            });
        }
    }
}
