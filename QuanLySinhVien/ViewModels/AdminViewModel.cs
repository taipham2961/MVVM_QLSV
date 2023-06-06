using QuanLySinhVien.Models;
using QuanLySinhVien.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySinhVien.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        //Tạo tập hợp chứa các phần tử tài khoản từ lớp TaiKhoan và binding vào DataGrid dgDanhSachTaiKhoan
        private ObservableCollection<TaiKhoan> _danhSachTaiKhoan;
        public ObservableCollection<TaiKhoan> DanhSachTaiKhoan
        {
            get => _danhSachTaiKhoan;
            set
            {
                _danhSachTaiKhoan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính TenTaiKhoan binding txbTenTaiKhoan để lấy và hiển thị dữ liệu tên tài khoản đăng nhập
        private string _tenTaiKhoan;

        public string TenTaiKhoan
        {
            get => _tenTaiKhoan;
            set
            {
                _tenTaiKhoan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoDem binding txbHoDem để lấy và hiển thị dữ liệu họ đệm người đăng kí tài khoản
        private string _hoDem;

        public string HoDem
        {
            get => _hoDem;
            set
            {
                _hoDem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính Ten binding txbTen để lấy và hiển thị dữ liệu tên người đăng kí tài khoản
        private string _ten;

        public string Ten
        {
            get => _ten;
            set
            {
                _ten = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính GioiTinh binding txbGioiTinh để lấy và hiển thị dữ liệu giới tính người đăng kí tài khoản
        private string _gioiTinh;

        public string GioiTinh
        {
            get => _gioiTinh;
            set
            {
                _gioiTinh = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính GioiTinh binding txbGioiTinh để lấy và hiển thị dữ liệu giới tính người đăng kí tài khoản
        private DateTime? _ngaySinh;

        public DateTime? NgaySinh
        {
            get => _ngaySinh;
            set
            {
                _ngaySinh = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính QueQuan binding txbQueQuan để lấy và hiển thị dữ liệu quê quán người đăng kí tài khoản
        private string _queQuan;

        public string QueQuan
        {
            get => _queQuan;
            set
            {
                _queQuan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SoDT binding txbSoDT để lấy và hiển thị dữ liệu số điện thoại người đăng kí tài khoản
        private string _soDT;

        public string SoDT
        {
            get => _soDT;
            set
            {
                _soDT = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SelectedItem để lấy giá trị các thuộc tính của TaiKhoan từ DataGrid dgDanhSachTaiKhoan
        //Binding vào thuộc tính SelectedItem của DataGrid dgDanhSachTaiKhoan
        private TaiKhoan _selectedItem;
        public TaiKhoan SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (_selectedItem != null)
                {
                    TenTaiKhoan = SelectedItem.TenTK;
                    HoDem = SelectedItem.HoDem;
                    Ten = SelectedItem.Ten;
                    GioiTinh = SelectedItem.GioiTinh;
                    NgaySinh = SelectedItem.NgaySinh;
                    QueQuan = SelectedItem.QueQuan;
                    SoDT = SelectedItem.SoDT;
                }
            }
        }

        //Thuộc tính MatKhauMoi và NhapLaiMK để lấy mật khẩu của người dùng đã nhập
        //Thông qua Command PasswordChangedCommand
        public string MatKhauMoi { get; set; }
        public string NhapLaiMK { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbMatKhauMoi
        public ICommand PasswordChangedCommand_MatKhauMoi { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbNhapLaiMK
        public ICommand PasswordChangedCommand_NhapLaiMK { get; set; }

        //Khai báo command đổi mật khẩu binding lên btnDoiMatKhau
        public ICommand DoiMatKhauCommand { get; set; }

        //Khai báo command cập nhật thông tin binding lên btnCapNhat
        public ICommand CapNhatCommand { get; set; }

        //Khai báo command tạo tài khoản binding lên btnTaoTaiKhoan
        public ICommand TaoTaiKhoanCommand { get; set; }

        //Khai báo command xóa tài khoản binding lên btnXoaTaiKhoan
        public ICommand XoaTaiKhoanCommand { get; set; }

        //Khai báo command đổ lại dữ liệu binding lên btnReload
        public ICommand ReloadCommand { get; set; }

        //Khai báo command thoát window AdminView binding lên btnExit
        public ICommand ExitCommand { get; set; }

        public AdminViewModel()
        {
            QLSVDataContext db = new QLSVDataContext();

            //Đổ dữ liệu vào DanhSachTaiKhoan và binding nó vào DataGrid dgDanhSachTaiKhoan
            //Để hiện thị dữ liệu các tài khoản đã đăng kí
            DanhSachTaiKhoan = new ObservableCollection<TaiKhoan>(db.TaiKhoans);

            //Command bắt sự kiện PasswordChanged ở pwbMatKhauMoi khi người dùng nhập mật khẩu ở pwbMatKhauMoi
            //CommandParameter truyền vào là pwbMatKhauCu để lấy mật khẩu lưu vào thuộc tính MatKhauMoi
            PasswordChangedCommand_MatKhauMoi = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {

                MatKhauMoi = p.Password;
            });

            //Command bắt sự kiện PasswordChanged ở pwbNhapLaiMK khi người dùng nhập mật khẩu ở pwbNhapLaiMK
            //CommandParameter truyền vào là pwbNhapLaiMK để lấy mật khẩu lưu vào thuộc tính NhapLaiMK
            PasswordChangedCommand_NhapLaiMK = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NhapLaiMK = p.Password;
            });

            //Command thực hiện việc đổi mật khẩu từ 1 tài khoản
            DoiMatKhauCommand = new RelayCommand<object>((p) =>
            {
                //Điều kiện để command hoạt động là thuộc tính TenTaiKhoan khác null
                return TenTaiKhoan != null;
            }, (p) =>
            {
                //Bắt lỗi truy vấn dữ liệu Linq
                try
                {
                    //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng TaiKhoan
                    //Với điều kiện tên tài khoản bằng TenTaiKhoan
                    TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan);
                    //Kiểm tra xem MatKhauMoi có bằng NhapLaiMK hay không
                    if (MatKhauMoi == NhapLaiMK)
                    {
                        //Nếu MatKhauMoi bằng NhapLaiMK thì thực hiện việc thay đổi mật khẩu
                        //Giá trị MatKhau của đối tượng tk lớp TaiKhoan bằng với giá trị của MatKhauMoi
                        tk.MatKhau = MatKhauMoi;
                        //Cập nhật lại thay đổi trong bảng TaiKhoan và thông báo đổi mật khẩu thành công
                        db.SubmitChanges();
                        MessageBox.Show("Đổi mật khẩu thành công!");
                    }
                    else
                    {
                        //Nếu mật khẩu mới không trùng với giá trị Nhập lại mật khẩu
                        MessageBox.Show("Mật khẩu nhập lại không trùng!");
                    }
                }
                catch
                {
                    //Thông báo lỗi
                    MessageBox.Show("Tên tài khoản không tồn tại!");
                }
            });

            //Command thực hiện việc cập nhật thông tin tài khoản
            CapNhatCommand = new RelayCommand<object>((p) =>
            {
                //Điều kiện để command hoạt động là thuộc tính TenTaiKhoan khác null
                return SelectedItem != null;
            }, (p) =>
            {
                //Bắt lỗi nhập dữ liệu
                try
                {
                    //Kiểm tra điều kiện nếu số điện thoại có 10 số và chuyển được sang dạng số
                    if (SoDT.Length == 10 && int.TryParse(SoDT, out int numValue))
                    {
                        //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng TaiKhoan
                        //Với điều kiện tên tài khoản bằng TenTaiKhoan
                        TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan);
                        //Sửa các thông tin cần sửa
                        tk.HoDem = HoDem;
                        tk.Ten = Ten;
                        tk.GioiTinh = GioiTinh;
                        tk.NgaySinh = (DateTime)NgaySinh;
                        tk.QueQuan = QueQuan;
                        tk.SoDT = SoDT;
                        //Cập nhật lại thay đổi trong bảng TaiKhoan và thông báo sửa thành công
                        db.SubmitChanges();
                        MessageBox.Show("Sửa thành công!");
                    }
                    else
                    {
                        //Thông báo nếu số điện thoại không đúng 10 số hoặc nhập dữ liệu số điện thoại sai
                        MessageBox.Show("Số điện thoại phải 10 số hoặc dữ liệu số điện thoại không hợp lệ!");
                    }
                }
                catch
                {
                    //Thông báo lỗi nhập dữ liệu
                    MessageBox.Show("Lỗi nhập dữ liệu!");
                }
            });

            //Command xóa tài khoản từ bảng TaiKhoan trên database
            //Điều kiện để command này thực thi là SelectedItem != null
            XoaTaiKhoanCommand = new RelayCommand<object>((p) => { return SelectedItem != null; }, (p) =>
            {
                //Lấy duy nhất 1 phần tử trên TaiKhoan với điều kiện là phần tử đó với thuộc tính TenTK bằng TenTaiKhoan
                TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan);
                //Xóa tài khoản 
                db.TaiKhoans.DeleteOnSubmit(tk);
                //Cập nhật lại thay đổi trong bảng TaiKhoan và thông báo sửa thành công
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công!");
                //Gán các giá trị thuộc tính bằng rỗng,thuộc tính ngày sinh bằng null
                TenTaiKhoan = "";
                HoDem = "";
                Ten = "";
                GioiTinh = "";
                NgaySinh = null;
                QueQuan = "";
                SoDT = "";
                //Đổ lại dữ liệu DanhSachTaiKhoan
                DanhSachTaiKhoan = new ObservableCollection<TaiKhoan>(db.TaiKhoans);
            });

            //TaoTaiKhoanCommand sẽ thực hiện các lệnh mở window RegisterView ở dạng Dialog
            TaoTaiKhoanCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RegisterView registerView = new RegisterView();
                registerView.ShowDialog();
            });

            //Command thoát cửa sổ của chính window AdminView thông qua command parameter truyền vào là adminView
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });

            //Command đổ lại dữ liệu từ bảng Tài khoản vào DanhSachTaiKhoan
            ReloadCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DanhSachTaiKhoan = new ObservableCollection<TaiKhoan>(db.TaiKhoans);
            });
        }
    }
}