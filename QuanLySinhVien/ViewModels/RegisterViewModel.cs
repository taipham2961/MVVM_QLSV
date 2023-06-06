using QuanLySinhVien.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySinhVien.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        //Thuộc tính TenTaiKhoan binding lên txbTenTaiKhoan để lấy thông tin tên đăng nhập từ người nhập
        public string TenTaiKhoan { get; set; }

        //Thuộc tính MatKhau để lấy mật khẩu của người dùng đã nhập thông qua Command PasswordChangedCommand
        public string MatKhau { get; set; }

        //Thuộc tính NhapLaiMK để lấy mật khẩu của người dùng đã nhập thông qua Command PasswordChangedCommand
        public string NhapLaiMK { get; set; }

        //Thuộc tính HoDem binding lên txbHoDem để lấy thông tin họ đệm từ người nhập
        public string HoDem { get; set; }

        //Thuộc tính Ten binding lên txbTen để lấy thông tin tên từ người nhập
        public string Ten { get; set; }

        //Thuộc tính GioiTinh binding lên txbGioiTinh để lấy thông tin giới tính từ người nhập
        public string GioiTinh { get; set; }

        //Thuộc tính NgaySinh binding lên txbNgaySinh để lấy thông tin ngày sinh từ người nhập
        public DateTime? NgaySinh { get; set; }

        //Thuộc tính QueQuan binding lên txbQueQuan để lấy thông tin quê quán từ người nhập
        public string QueQuan { get; set; }

        //Thuộc tính SoDT binding lên txbSoDT để lấy thông tin số điện thoại từ người nhập
        public string SoDT { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbMatKhau 
        public ICommand PasswordChangedCommand_MatKhau { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbNhapLaiMK
        public ICommand PasswordChangedCommand_NhapLaiMK { get; set; }

        //Khai báo command tạo tài khoản binding lên btnTaoTaiKhoan
        public ICommand TaoTaiKhoanCommand { get; set; }

        //Khai báo command thoát binding lên btnExit
        public ICommand ExitCommand { get; set; }

        public RegisterViewModel()
        {
            QLSVDataContext db = new QLSVDataContext();

            //Command bắt sự kiện PasswordChanged ở pwbMatKhau khi người dùng nhập mật khẩu ở pwbMatKhau
            //CommandParameter truyền vào là pwbMatKhau để lấy mật khẩu lưu vào thuộc tính MatKhau
            PasswordChangedCommand_MatKhau = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                MatKhau = p.Password;
            });

            //Command bắt sự kiện PasswordChanged ở pwbNhapLaiMK khi người dùng nhập mật khẩu ở pwbNhapLaiMK
            //CommandParameter truyền vào là pwbNhapLaiMK để lấy mật khẩu lưu vào thuộc tính NhapLaiMK
            PasswordChangedCommand_NhapLaiMK = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NhapLaiMK = p.Password;
            });

            //Command thực hiện việc tạo tài khoản
            TaoTaiKhoanCommand = new RelayCommand<object>((p) =>
            {
                //Điều kiện để command thực hiện là tất cả dữ liệu nhập vào khác null
                return TenTaiKhoan != null && MatKhau != null && NhapLaiMK != null
                        && HoDem != null && Ten != null && GioiTinh != null && NgaySinh != null
                        && QueQuan != null && SoDT != null;
            }, (p) =>
            {
                //Bắt lỗi khi thực hiện việc thêm tài khoản vào database
                try
                {
                    //Kiểm tra mật khẩu nhập vào trùng với phần nhập lại mật khẩu
                    //Và nếu số điện thoại có 10 số và chuyển được sang dạng số
                    if (MatKhau == NhapLaiMK && (SoDT.ToString().Length == 10 && int.TryParse(SoDT, out int numValue)))
                    {
                        //Tạo biến tk kiểu TaiKhoan để lưu giá trị tất cả thuộc tính của TaiKhoan
                        TaiKhoan tk = new TaiKhoan
                        {
                            TenTK = TenTaiKhoan,
                            MatKhau = MatKhau,
                            HoDem = HoDem,
                            Ten = Ten,
                            GioiTinh = GioiTinh,
                            NgaySinh = (DateTime)NgaySinh,
                            QueQuan = QueQuan,
                            SoDT = SoDT
                        };
                        //Thêm tài khoản vào bảng TaiKhoan
                        db.TaiKhoans.InsertOnSubmit(tk);
                        //cập nhật lại thay đổi bảng TaiKhoan
                        db.SubmitChanges();
                        //Thông báo tạo tài khoản thành công
                        MessageBox.Show("Tạo tài khoản thành công!");
                    }
                    else
                    {
                        //Thông báo lỗi
                        MessageBox.Show("Mật khẩu nhập lại không khớp hoặc số điện thoại phải 10 số và chuỗi các số!");
                    }
                }
                catch
                {
                    //Thông báo lỗi
                    MessageBox.Show("Lỗi thêm tài khoản!Trùng tên tài khoản đã tồn tại hoặc chưa nhập ngày sinh!");
                }
            });

            //Command thoát sẽ thực hiện chức năng đăng nhập khi nhấn nút btnExit
            //Thông qua Command Parameter truyền vào là registerView
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
        }
    }
}
