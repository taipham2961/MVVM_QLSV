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
    public class ManagerViewModel : BaseViewModel
    {
        //Thuộc tính TaiKhoan để lấy dữ liệu được truyền vào từ LoginViewModel
        public static string TaiKhoan { get; set; }

        //Khai báo command bắt sự kiện LoadedWindow trên ManagerView
        public ICommand LoadedWindowCommand { get; set; }

        //Gom nhóm các thuộc tính của TabItem Sinh Viên

        #region Property_SinhVien

        //Khai báo thuộc tính _TrangThaiThem_SinhVien kiểu bool làm flag
        //Kiểm tra xem Button Thêm sinh viên được kích hoạt chưa
        private bool _TrangThaiThem_SinhVien = false;

        //Phương thức OnPropertyChanged để kích hoạt sự kiện thông báo nó có thay đổi một thuộc tính nào đó
        //Tạo tập hợp chứa các phần tử sinh viên từ lớp SinhVien và binding vào DataGrid dgDanhSachSinhVien
        private ObservableCollection<SinhVien> _danhSach_SinhVien;
        public ObservableCollection<SinhVien> DanhSach_SinhVien
        {
            get => _danhSach_SinhVien;
            set
            {
                _danhSach_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaSV_SinhVien binding txbMaSV để lấy và hiển thị dữ liệu mã sinh viên 
        private string _maSV_SinhVien;
        public string MaSV_SinhVien
        {
            get => _maSV_SinhVien;
            set
            {
                _maSV_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoDem_SinhVien binding txbHoDemSV để lấy và hiển thị dữ liệu họ đệm sinh viên
        private string _hoDem_SinhVien;
        public string HoDem_SinhVien
        {
            get => _hoDem_SinhVien;
            set
            {
                _hoDem_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính Ten_SinhVien binding txbTenSV để lấy và hiển thị dữ liệu tên sinh viên
        private string _ten_SinhVien;
        public string Ten_SinhVien
        {
            get => _ten_SinhVien;
            set
            {
                _ten_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaLop_SinhVien để lấy và hiển thị dữ liệu mã lớp của sinh viên
        private string _maLop_SinhVien;
        public string MaLop_SinhVien
        {
            get => _maLop_SinhVien;
            set
            {
                _maLop_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính GioiTinh_SinhVien binding txbGioiTinhSV để lấy và hiển thị dữ liệu giới tính sinh viên
        private string _gioiTinh_SinhVien;
        public string GioiTinh_SinhVien
        {
            get => _gioiTinh_SinhVien;
            set
            {
                _gioiTinh_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính QueQuan_SinhVien binding txbQueQuanSV để lấy và hiển thị dữ liệu quê quán sinh viên
        private string _queQuan_SinhVien;
        public string QueQuan_SinhVien
        {
            get => _queQuan_SinhVien;
            set
            {
                _queQuan_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SoDT_SinhVien binding txbSoDTSV để lấy và hiển thị dữ liệu số điện thoại sinh viên
        private string _soDT_SinhVien;
        public string SoDT_SinhVien
        {
            get => _soDT_SinhVien;
            set
            {
                _soDT_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính NgaySinh_SinhVien binding dpNgaySinhSV để lấy và hiển thị dữ liệu ngày sinh sinh viên
        private DateTime? _ngaySinh_SinhVien;
        public DateTime? NgaySinh_SinhVien
        {
            get => _ngaySinh_SinhVien;
            set
            {
                _ngaySinh_SinhVien = value;
                OnPropertyChanged();
            }
        }

        //Tạo tập hợp chứa các phần tử mã lớp kiểu string và binding vào Combobox cbMaLopTK và cbMaLopSV
        public ObservableCollection<string> DanhSachMaLop_SinhVien { get; set; }

        //Tạo tập hợp chứa các phần tử sinh viên từ lớp SinhVien
        //Làm biến trung gian để đổ dữ liệu vào DanhSach_SinhVien sau khi tìm kiếm
        public ObservableCollection<SinhVien> DanhSachTK_SinhVien { get; set; }

        //Thuộc tính MaSVTK_SinhVien binding txbMaSVTK lấy dữ liệu người dùng nhập để tìm kiếm
        public string MaSVTK_SinhVien { get; set; }

        //Thuộc tính HoTenTK_SinhVien binding txbHoTenTK lấy dữ liệu người dùng nhập để tìm kiếm
        public string HoTenTK_SinhVien { get; set; }

        //Thuộc tính HoDemTK_SinhVien chứa họ đệm sinh viên cần tìm kiếm từ Thuộc tính HoTenTK_SinhVien
        public string HoDemTK_SinhVien { get; set; }

        //Thuộc tính TenTK_SinhVien chứa tên sinh viên cần tìm kiếm từ Thuộc tính HoTenTK_SinhVien
        public string TenTK_SinhVien { get; set; }

        //Thuộc tính MaLopTK_SinhVien lấy mã lớp sinh viên cần tìm kiếm từ Combobox cbMaLopTK
        public string MaLopTK_SinhVien { get; set; }

        //Thuộc tính SelectedItem_SinhVien để lấy giá trị các thuộc tính của SinhVien từ DataGrid dgDanhSachSinhVien
        //Binding vào thuộc tính SelectedItem của DataGrid dgDanhSachSinhVien
        private SinhVien _selectedItem_SinhVien;
        public SinhVien SelectedItem_SinhVien
        {
            get => _selectedItem_SinhVien;
            set
            {
                _selectedItem_SinhVien = value;
                OnPropertyChanged();
                if (SelectedItem_SinhVien != null)
                {
                    MaSV_SinhVien = SelectedItem_SinhVien.MaSV.ToString();
                    HoDem_SinhVien = SelectedItem_SinhVien.HoDem;
                    Ten_SinhVien = SelectedItem_SinhVien.Ten;
                    MaLop_SinhVien = SelectedItem_SinhVien.MaLop;
                    GioiTinh_SinhVien = SelectedItem_SinhVien.GioiTinh;
                    NgaySinh_SinhVien = SelectedItem_SinhVien.NgaySinh;
                    QueQuan_SinhVien = SelectedItem_SinhVien.QueQuan;
                    SoDT_SinhVien = SelectedItem_SinhVien.SoDT;
                }
            }
        }

        //Khai báo command tìm kiếm sinh viên binding lên btnTimKiemSV
        public ICommand TimKiemCommand_SinhVien { get; set; }

        //Khai báo command cập nhật thông tin sinh viên binding lên btnCapNhatSV
        public ICommand CapNhatCommand_SinhVien { get; set; }

        //Khai báo command thêm sinh viên binding lên btnThemSV
        public ICommand ThemCommand_SinhVien { get; set; }

        //Khai báo command xóa sinh viên binding lên btnXoaSV
        public ICommand XoaCommand_SinhVien { get; set; }

        //Khai báo command OK binding lên btnOK_SinhVien
        public ICommand OKCommand_SinhVien { get; set; }

        //Khai báo command bảng điểm binding lên btnBangDiemSV
        public ICommand BangDiemCommand_SinhVien { get; set; }
        #endregion

        //Gom nhóm các thuộc tính của TabItem Danh sách điểm học phần

        #region Property_BangDiem

        //Thuộc tính MaSV_BangDiem binding txbMaSV_BangDiem để hiển thị dữ liệu mã sinh viên 
        private string _maSV_BangDiem;
        public string MaSV_BangDiem
        {
            get => _maSV_BangDiem;
            set
            {
                _maSV_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoTen_BangDiem binding txbHoten_BangDiem để hiển thị dữ liệu họ tên sinh viên 
        private string _hoTen_BangDiem;
        public string HoTen_BangDiem
        {
            get => _hoTen_BangDiem;
            set
            {
                _hoTen_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaLop_BangDiem binding txbMaLop_BangDiem để hiển thị dữ liệu mã lớp sinh viên 
        private string _maLop_BangDiem;
        public string MaLop_BangDiem
        {
            get => _maLop_BangDiem;
            set
            {
                _maLop_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính GioiTinh_BangDiem binding txbGioiTinh_BangDiem để hiển thị dữ liệu giới tính sinh viên 
        private string _gioiTinh_BangDiem;
        public string GioiTinh_BangDiem
        {
            get => _gioiTinh_BangDiem;
            set
            {
                _gioiTinh_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính QueQuan_BangDiem binding txbQueQuan_BangDiem để hiển thị dữ liệu quê quán sinh viên
        private string _queQuan_BangDiem;
        public string QueQuan_BangDiem
        {
            get => _queQuan_BangDiem;
            set
            {
                _queQuan_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SoDT_BangDiem binding txbSoDT_BangDiem để hiển thị dữ liệu số điện thoại sinh viên
        private string _soDT_BangDiem;
        public string SoDT_BangDiem
        {
            get => _soDT_BangDiem;
            set
            {
                _soDT_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính NgaySinh_BangDiem binding txbNgaySinh_BangDiem để hiển thị dữ liệu ngày sinh sinh viên
        private DateTime? _ngaySinh_BangDiem;
        public DateTime? NgaySinh_BangDiem
        {
            get => _ngaySinh_BangDiem;
            set
            {
                _ngaySinh_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Tạo tập hợp chứa các phần tử và binding vào DataGrid dgBangDiem
        private ObservableCollection<object> _danhSach_BangDiem;
        public ObservableCollection<object> DanhSach_BangDiem
        {
            get => _danhSach_BangDiem;
            set
            {
                _danhSach_BangDiem = value;
                OnPropertyChanged();
            }
        }

        //Khai báo command in binding lên btnPrint
        public ICommand PrintCommand_BangDiem { get; set; }
        #endregion

        //Gom nhóm các thuộc tính của TabItem Điểm và học phần
        #region Property_Diem_HocPhan

        //Khai báo thuộc tính DaNhapDiem kiểm tra môn đó được nhập điểm hay chưa?
        private bool DaNhapDiem;
        //Thuộc tính MaSVTK_Diem binding lên txbMaSVTK_Diem
        //Để lấy dữ liệu mã sinh viên tìm kiếm của người dùng nhập
        public string MaSVTK_Diem { get; set; }
        //Thuộc tính MaHPTK_Diem binding lên txbMaHPTK_Diem
        //Để lấy dữ liệu mã học phần của người dùng nhập
        public string MaHPTK_Diem { get; set; }

        //Thuộc tính MaSV_BangDiem binding txbMaSV_Diem để hiển thị dữ liệu mã sinh viên
        private string _maSV_Diem;
        public string MaSV_Diem
        {
            get => _maSV_Diem;
            set
            {
                _maSV_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoTen_Diem binding txbHoTen_Diem để hiển thị dữ liệu họ tên sinh viên
        private string _hoTen_Diem;
        public string HoTen_Diem
        {
            get => _hoTen_Diem;
            set
            {
                _hoTen_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaLop_Diem binding txbMaLop_Diem để hiển thị dữ liệu mã lớp sinh viên
        private string _maLop_Diem;
        public string MaLop_Diem
        {
            get => _maLop_Diem;
            set
            {
                _maLop_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaHP_Diem binding txbMaHP_Diem để hiển thị dữ liệu mã học phần
        private string _maHP_Diem;

        public string MaHP_Diem
        {
            get => _maHP_Diem;
            set
            {
                _maHP_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính TenHP_Diem binding txbTenHP_Diem để hiển thị dữ liệu tên học phần
        private string _tenHP_Diem;

        public string TenHP_Diem
        {
            get => _tenHP_Diem;
            set
            {
                _tenHP_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính TenHP_Diem binding txbTenHP_Diem để hiển thị dữ liệu tên học phần
        private string _soTC_Diem;

        public string SoTC_Diem
        {
            get => _soTC_Diem;
            set
            {
                _soTC_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính DiemCC_Diem binding txbDiemCC_Diem để hiển thị dữ liệu điểm chuyên cần
        private float _diemCC_Diem;

        public float DiemCC_Diem
        {
            get => _diemCC_Diem;
            set
            {
                _diemCC_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính DiemGK_Diem binding txbDiemGK_Diem để hiển thị dữ liệu điểm giữa kỳ
        private float _diemGK_Diem;

        public float DiemGK_Diem
        {
            get => _diemGK_Diem;
            set
            {
                _diemGK_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính DiemCK_Diem binding txbDiemCK_Diem để hiển thị dữ liệu điểm cuối kỳ
        private float _diemCK_Diem;

        public float DiemCK_Diem
        {
            get => _diemCK_Diem;
            set
            {
                _diemCK_Diem = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính ThongTinNhapDiem_Diem binding txbThongTinNhapDiem_Diem để hiển thị học phần đó nhập điểm chưa
        private string _thongTinNhapDiem_Diem;

        public string ThongTinNhapDiem_Diem
        {
            get => _thongTinNhapDiem_Diem;
            set
            {
                _thongTinNhapDiem_Diem = value;
                OnPropertyChanged();
            }
        }

        //Khai báo thuộc tính _TrangThaiThem_HocPhan kiểu bool làm flag
        //Kiểm tra xem Button Thêm học phần được kích hoạt chưa
        private bool _TrangThaiThem_HocPhan = false;

        //Tạo tập hợp chứa các phần tử học phần từ lớp HocPhan và binding vào DataGrid dgDanhSachHocPhan
        private ObservableCollection<HocPhan> _danhSach_HocPhan;

        public ObservableCollection<HocPhan> DanhSach_HocPhan
        {
            get => _danhSach_HocPhan;
            set
            {
                _danhSach_HocPhan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MaHP_HocPhan binding txbMaHP_HocPhan để hiển thị mã học phần
        private string _maHP_HocPhan;

        public string MaHP_HocPhan
        {
            get => _maHP_HocPhan;
            set
            {
                _maHP_HocPhan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính TenHP_HocPhan binding txbTenHP_HocPhan để hiển thị tên học phần
        private string _tenHP_HocPhan;

        public string TenHP_HocPhan
        {
            get => _tenHP_HocPhan;
            set
            {
                _tenHP_HocPhan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SoTC_HocPhan binding txbSoTC_HocPhan để hiển thị số tín chỉ học phần
        private string _soTC_HocPhan;

        public string SoTC_HocPhan
        {
            get => _soTC_HocPhan;
            set
            {
                _soTC_HocPhan = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SelectedItem_HocPhan để lấy giá trị các thuộc tính của HocPhan từ DataGrid dgDanhSachHocPhan
        //Binding vào thuộc tính SelectedItem của DataGrid dgDanhSachHocPhan
        private HocPhan _selectedItem_HocPhan;

        public HocPhan SelectedItem_HocPhan
        {
            get => _selectedItem_HocPhan;
            set
            {
                _selectedItem_HocPhan = value;
                OnPropertyChanged();
                if (SelectedItem_HocPhan != null)
                {
                    MaHP_HocPhan = SelectedItem_HocPhan.MaHP;
                    TenHP_HocPhan = SelectedItem_HocPhan.TenHP;
                    SoTC_HocPhan = SelectedItem_HocPhan.SoTC.ToString();
                }
            }
        }

        //Khai báo command kiểm tra sinh viên binding lên btnKiemTraSV
        public ICommand KiemTraSVCommand_Diem { get; set; }

        //Khai báo command kiểm tra học phần binding lên btnKiemTraHP
        public ICommand KiemTraHPCommand_Diem { get; set; }

        //Khai báo command nhập điểm binding lên btnNhapDiem
        public ICommand NhapDiemCommand_Diem { get; set; }

        //Khai báo command sửa điểm binding lên btnSuaDiem
        public ICommand SuaDiemCommand_Diem { get; set; }

        //Khai báo command xóa điểm binding lên btnXoaDiem
        public ICommand XoaDiemCommand_Diem { get; set; }


        //Khai báo command cập nhật học phần binding lên btnCapNhatHocPhan
        public ICommand CapNhatCommand_HocPhan { get; set; }

        //Khai báo command xóa học phần binding lên btnXoaHocPhan
        public ICommand XoaCommand_HocPhan { get; set; }

        //Khai báo command thêm học phần binding lên btnThemHocPhan
        public ICommand ThemCommand_HocPhan { get; set; }

        //Khai báo command OK binding lên btnOK_HocPhan
        public ICommand OKCommand_HocPhan { get; set; }
        #endregion

        //Gom nhóm các thuộc tính của TabItem Thông tin tài khoản

        #region Property_Info

        //Thuộc tính TenTaiKhoan_Info binding txbTenTaiKhoan_Info để hiển thị dữ liệu tên tài khoản đã đăng nhập
        private string _tenTaiKhoan_Info;

        public string TenTaiKhoan_Info
        {
            get => _tenTaiKhoan_Info;
            set
            {
                _tenTaiKhoan_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoDem_Info binding txbHoDem_Info để hiển thị dữ liệu họ đệm người dùng
        private string _hoDem_Info;

        public string HoDem_Info
        {
            get => _hoDem_Info;
            set
            {
                _hoDem_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính HoDem_Info binding txbHoDem_Info để hiển thị dữ liệu tên người dùng
        private string _ten_Info;

        public string Ten_Info
        {
            get => _ten_Info;
            set
            {
                _ten_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính GioiTinh_Info binding txbGioiTinh_Info để hiển thị dữ liệu giới tính người dùng
        private string _gioiTinh_Info;

        public string GioiTinh_Info
        {
            get => _gioiTinh_Info;
            set
            {
                _gioiTinh_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính QueQuan_Info binding txbQueQuan_Info để hiển thị dữ liệu quê quán người dùng
        private string _queQuan_Info;

        public string QueQuan_Info
        {
            get => _queQuan_Info;
            set
            {
                _queQuan_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính NgaySinh_Info binding txbNgaySinh_Info để hiển thị dữ liệu ngày sinh người dùng
        private DateTime? _ngaySinh_Info;

        public DateTime? NgaySinh_Info
        {
            get => _ngaySinh_Info;
            set
            {
                _ngaySinh_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính SoDT_Info binding txbSoDT_Info để hiển thị dữ liệu số điện thoại người dùng
        private string _soDT_Info;

        public string SoDT_Info
        {
            get => _soDT_Info;
            set
            {
                _soDT_Info = value;
                OnPropertyChanged();
            }
        }

        //Thuộc tính MatKhauCu_Info để lấy mật khẩu cũ của người dùng đã nhập
        //Thông qua Command PasswordChangedCommand_MatKhauCu_Info
        public string MatKhauCu_Info { get; set; }

        //Thuộc tính MatKhauMoi_Info để lấy mật khẩu cũ của người dùng đã nhập
        //Thông qua Command PasswordChangedCommand_MatKhauMoi_Info
        public string MatKhauMoi_Info { get; set; }

        //Thuộc tính NhapLaiMK_Info để lấy mật khẩu cũ của người dùng đã nhập
        //Thông qua Command PasswordChangedCommand_NhapLaiMK_Info
        public string NhapLaiMK_Info { get; set; }


        //Khai báo command để bắt sự kiện PasswordChanged trên pwbMatKhauCu
        public ICommand PasswordChangedCommand_MatKhauCu_Info { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbMatKhauMoi
        public ICommand PasswordChangedCommand_MatKhauMoi_Info { get; set; }

        //Khai báo command để bắt sự kiện PasswordChanged trên pwbNhapLaiMK
        public ICommand PasswordChangedCommand_NhapLaiMK_Info { get; set; }

        //Khai báo command cập nhật thông tin binding lên btnCapNhatInfo
        public ICommand CapNhatCommand_Info { get; set; }

        //Khai báo command đổi mật khẩu binding lên btnDoiMatKhau
        public ICommand DoiMatKhauCommand_Info { get; set; }

        //Khai báo command vào Admin binding lên btnAdmin
        public ICommand AdminCommand_Info { get; set; }

        //Khai báo command đăng xuất binding lên btnDangXuat
        public ICommand DangXuatCommand_Info { get; set; }

        //Khai báo command thoát ứng dụng binding lên btnExit
        public ICommand ExitCommand_Info { get; set; }
        #endregion

        //Hàm dựng của lớp ManagerViewModel có tham số truyền vào
        public ManagerViewModel(string taiKhoan)
        {
            //Thuộc tính TaiKhoan lấy giá trị tham số truyền vào
            TaiKhoan = taiKhoan;
            //Khai báo đối tượng managerView từ lớp ManagerView để mở window
            ManagerView managerView = new ManagerView();
            managerView.Show();
        }

        public ManagerViewModel()
        {
            QLSVDataContext db = new QLSVDataContext();

            //Đổ dữ liệu vào DanhSach_SinhVien và binding nó vào DataGrid dgDanhSachSinhVien
            //Để hiện thị dữ liệu các sinh viên
            DanhSach_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens);
            //Đổ dữ liệu vào DanhSachMaLop_SinhVien và binding nó vào Combobox cbMaLopTK và cbMaLopSV
            //Để hiển thị danh sách các mã lớp từ bảng ThongTinLop
            DanhSachMaLop_SinhVien = new ObservableCollection<string>(db.ThongTinLops.Select(x => x.MaLop));
            //Đổ dữ liệu vào DanhSach_HocPhan và binding nó vào DataGrid dgDanhSachHocPhan
            //Để hiển thị dũ liệu các học phần
            DanhSach_HocPhan = new ObservableCollection<HocPhan>(db.HocPhans);

            //Command thực hiện lấy dữ liệu thông tin về người đăng nhập vào ứng dụng
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TenTaiKhoan_Info = TaiKhoan;
                TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan_Info);
                HoDem_Info = tk.HoDem;
                Ten_Info = tk.Ten;
                GioiTinh_Info = tk.GioiTinh;
                QueQuan_Info = tk.QueQuan;
                NgaySinh_Info = tk.NgaySinh;
                SoDT_Info = tk.SoDT;
            });

            //Thực hiện tìm kiếm sinh viên qua mã sinh viên,họ tên và mã lớp
            TimKiemCommand_SinhVien = new RelayCommand<object>((p) =>
            {
                //Nếu Thuộc tính HoTenTK_SinhVien bằng null thì gán lại giá trị đó bằng rỗng("")
                //Ngược lại tách chuỗi HoTenTK_SinhVien thành 2 phần:phần họ đệm và phần tên
                if (HoTenTK_SinhVien == null)
                {
                    HoTenTK_SinhVien = "";
                }
                else
                {
                    string[] str = HoTenTK_SinhVien.Trim().Split(' ');
                    TenTK_SinhVien = str[str.Length - 1];
                    HoDemTK_SinhVien = "";
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        HoDemTK_SinhVien += str[i] + ' ';
                    }
                }

                //Nếu Thuộc tính MaSVTK_SinhVien bằng null thì gán lại giá trị đó bằng rỗng
                if (MaSVTK_SinhVien == null)
                {
                    MaSVTK_SinhVien = "";
                }

                //Nếu Thuộc tính MaLopTK_SinhVien bằng null thì gán lại giá trị đó bằng rỗng
                if (MaLopTK_SinhVien == null)
                {
                    MaLopTK_SinhVien = "";
                }

                return true;
            }, (p) =>
            {
                //Nếu thuộc tính MaSVTK_SinhVien khác rỗng
                if (MaSVTK_SinhVien != "")
                {
                    //Nếu thuộc tính HoTenTK_SinhVien và MaLopTK_SinhVien bằng rỗng
                    if (HoTenTK_SinhVien == "" && MaLopTK_SinhVien == "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện mã sinh viên trong bảng bằng mã sinh viên tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaSV.ToString() == MaSVTK_SinhVien.Trim()));
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien khác rỗng nhưng MaLopTK_SinhVien bằng rỗng
                    else if (HoTenTK_SinhVien != "" && MaLopTK_SinhVien == "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện mã sinh viên trong bảng bằng mã sinh viên tìm kiếm
                        //Và họ đệm bằng với họ đệm sinh viên tìm kiếm ,tên bằng tên sinh viên tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaSV.ToString() == MaSVTK_SinhVien.Trim() &&
                        sv.HoDem == HoDemTK_SinhVien &&
                        sv.Ten == TenTK_SinhVien));
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien bằng rỗng nhưng MaLopTK_SinhVien khác rỗng
                    else if (HoTenTK_SinhVien == "" && MaLopTK_SinhVien != "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện mã sinh viên trong bảng bằng mã sinh viên tìm kiếm
                        //Và mã lớp bằng với mã lớp tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaSV.ToString() == MaSVTK_SinhVien.Trim() &&
                        sv.MaLop == MaLopTK_SinhVien.Trim()));
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien và MaLopTK_SinhVien bằng rỗng
                    else if (HoTenTK_SinhVien != "" && MaLopTK_SinhVien != "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện mã sinh viên trong bảng bằng mã sinh viên tìm kiếm
                        //Họ đệm bằng với họ đệm sinh viên tìm kiếm ,tên bằng tên sinh viên tìm kiếm
                        //Và mã lớp bằng với mã lớp tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaSV.ToString() == MaSVTK_SinhVien.Trim() &&
                        sv.MaLop == MaLopTK_SinhVien.Trim() &&
                        sv.HoDem == HoDemTK_SinhVien &&
                        sv.Ten == TenTK_SinhVien));
                    }
                }
                //Ngược lại thuộc tính MaSVTK_SinhVien bằng rỗng
                else
                {
                    //Nếu thuộc tính HoTenTK_SinhVien và MaLopTK_SinhVien bằng rỗng
                    if (HoTenTK_SinhVien == "" && MaLopTK_SinhVien == "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens);
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien khác rỗng nhưng MaLopTK_SinhVien bằng rỗng
                    else if (HoTenTK_SinhVien != "" && MaLopTK_SinhVien == "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện họ đệm bằng với họ đệm sinh viên tìm kiếm ,tên bằng tên sinh viên tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.HoDem == HoDemTK_SinhVien &&
                        sv.Ten == TenTK_SinhVien));
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien bằng rỗng nhưng MaLopTK_SinhVien khác rỗng
                    else if (HoTenTK_SinhVien == "" && MaLopTK_SinhVien != "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với điều kiện mã lớp bằng với mã lớp tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaLop == MaLopTK_SinhVien.Trim()));
                    }
                    //Ngược lại nếu thuộc tính HoTenTK_SinhVien và MaLopTK_SinhVien bằng rỗng
                    else if (HoTenTK_SinhVien != "" && MaLopTK_SinhVien != "")
                    {
                        //Đổ dữ liệu vào DanhSachTK_SinhVien từ bảng sinh viên
                        //Với họ đệm bằng với họ đệm sinh viên tìm kiếm ,tên bằng tên sinh viên tìm kiếm
                        //Và mã lớp bằng với mã lớp tìm kiếm
                        DanhSachTK_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens.Where(sv => sv.MaLop == MaLopTK_SinhVien.Trim() &&
                        sv.HoDem == HoDemTK_SinhVien &&
                        sv.Ten == TenTK_SinhVien));
                    }
                }
                //Thuộc tính DanhSach_SinhVien lấy dữ liệu từ DanhSachTK_SinhVien để hiển thị danh sách sinh viên tìm kiếm
                DanhSach_SinhVien = DanhSachTK_SinhVien;
            });

            //Command thực hiện việc cập nhật lại thông tin sinh viên
            CapNhatCommand_SinhVien = new RelayCommand<object>((p) =>
            {
                //Điều kiện để thực thi là MaSV_SinhVien khác rỗng để để chỉnh sửa dữ liệu
                /*Và _TrangThaiThem_SinhVien bằng false để tránh trường hợp đang
                / thêm sinh viên mà các button khác có khả năng nhấn được gây lỗi*/
                return _TrangThaiThem_SinhVien == false && MaSV_SinhVien != "";
            }, (p) =>
            {
                //Bắt lỗi khi thực hiện cập nhật
                try
                {
                    //Kiểm tra điều kiện nếu số điện thoại có 10 số và chuyển được sang dạng số
                    if (SoDT_SinhVien.ToString().Length == 10 && int.TryParse(SoDT_SinhVien, out int numValue))
                    {
                        //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng SinhVien
                        //Với điều kiện mã sinh viên trong bảng SinhVien bằng MaSV_SinhVien và gán nó vào biến sv kiểu SinhVien
                        SinhVien sv = db.SinhViens.Single(x => x.MaSV.ToString() == MaSV_SinhVien);
                        //Sửa dữ liệu trong sv
                        sv.HoDem = HoDem_SinhVien;
                        sv.Ten = Ten_SinhVien;
                        sv.MaLop = MaLop_SinhVien;
                        sv.GioiTinh = GioiTinh_SinhVien;
                        sv.NgaySinh = (DateTime)NgaySinh_SinhVien;
                        sv.QueQuan = QueQuan_SinhVien;
                        sv.SoDT = SoDT_SinhVien;
                        //Cập nhật lại thay đổi
                        db.SubmitChanges();
                        //Thông báo thành công
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
                    //Thông báo lỗi
                    MessageBox.Show("Lỗi nhập dữ liệu!");
                }
            });

            //Command thực thi việc hiển thị bảng điểm trên TabItem Danh sách điểm học phần
            BangDiemCommand_SinhVien = new RelayCommand<TabControl>((p) =>
            {
                return _TrangThaiThem_SinhVien == false && MaSV_SinhVien != "";
            }, (p) =>
            {
                //Truyền các thông tin thuộc tính từ TabItem SinhVien sang TabItem BangDiem
                MaSV_BangDiem = MaSV_SinhVien;
                HoTen_BangDiem = HoDem_SinhVien + " " + Ten_SinhVien;
                MaLop_BangDiem = MaLop_SinhVien;
                GioiTinh_BangDiem = GioiTinh_SinhVien;
                NgaySinh_BangDiem = NgaySinh_SinhVien;
                QueQuan_BangDiem = QueQuan_SinhVien;
                SoDT_BangDiem = SoDT_SinhVien;
                //Câu lệnh truy vấn Linq lấy dữ liệu đổ vào DanhSach_BangDiem từ bảng BangDiem và bảng HocPhan
                DanhSach_BangDiem = new ObservableCollection<object>(db.BangDiems.Where(x => x.MaSV.ToString() == MaSV_BangDiem)
                    .Join(db.HocPhans, x => x.MaHP, y => y.MaHP, (x, y) => new
                    {
                        y.MaHP,
                        y.TenHP,
                        y.SoTC,
                        x.DiemCC,
                        x.DiemGK,
                        x.DiemCK,
                        KetQua = x.DiemCC * 0.1 + x.DiemGK * 0.2 + x.DiemCK * 0.7
                    }));
                //Chuyển sang TabItem tiếp theo - TabItem BangDiem(Danh sách điểm học phần)
                p.SelectedIndex++;
            });

            //Command thực hiện việc làm trống các thuộc tính để thêm sinh viên
            //Command Parameter là btnOK để hiện button OK
            ThemCommand_SinhVien = new RelayCommand<Button>((p) =>
            {
                return _TrangThaiThem_SinhVien == false;
            }, (p) =>
            {
                //Chuyển _TrangThaiThem_SinhVien sang true để đánh dấu các button trong TabItem SinhVien không hoạt động
                //Trừ button OK
                _TrangThaiThem_SinhVien = true;
                //Hiển thị button OK
                p.Visibility = Visibility.Visible;
                MaSV_SinhVien = "";
                HoDem_SinhVien = "";
                Ten_SinhVien = "";
                MaLop_SinhVien = "";
                GioiTinh_SinhVien = "";
                NgaySinh_SinhVien = null;
                QueQuan_SinhVien = "";
                SoDT_SinhVien = "";
            });

            //Command thực hiện việc thêm sinh viên
            //Command Parameter là btnOK để ẩn button OK
            OKCommand_SinhVien = new RelayCommand<Button>((p) =>
            {
                //Điều kiện để thực thi là _TrangThaiThem_SinhVien == true
                return _TrangThaiThem_SinhVien;
            }, (p) =>
            {
                //Bắt lỗi khi thực hiện việc thêm sinh viên vào database
                try
                {
                    //Kiểm tra điều kiện nếu số điện thoại có 10 số và chuyển được sang dạng số
                    if (SoDT_SinhVien.Length == 10 && int.TryParse(SoDT_SinhVien, out int numValue))
                    {
                        //Tạo biến sv kiểu SinhVien để lưu giá trị tất cả thuộc tính của SinhVien
                        //Trừ MaSV vì trong SQL Server nó là dạng IDENTITY
                        SinhVien sv = new SinhVien
                        {
                            HoDem = HoDem_SinhVien,
                            Ten = Ten_SinhVien,
                            MaLop = MaLop_SinhVien,
                            GioiTinh = GioiTinh_SinhVien,
                            NgaySinh = (DateTime)NgaySinh_SinhVien,
                            QueQuan = QueQuan_SinhVien,
                            SoDT = SoDT_SinhVien
                        };
                        //Thêm sinh viên mới vào bảng SinhVien và cập nhật thay đổi
                        db.SinhViens.InsertOnSubmit(sv);
                        db.SubmitChanges();
                        //Thông báo thêm thành công
                        MessageBox.Show("Thêm thành công!");
                        //Sau khi thêm sẽ trả _TrangThaiThem_SinhVien về false để các button khác hoạt động
                        _TrangThaiThem_SinhVien = false;
                        //Ẩn lại button OK
                        p.Visibility = Visibility.Collapsed;
                        //Đổ lại dữ liệu
                        DanhSach_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens);
                    }
                    else
                    {
                        //Thông báo nếu số điện thoại không đúng 10 số hoặc nhập dữ liệu số điện thoại sai
                        MessageBox.Show("Số điện thoại phải 10 số hoặc dữ liệu số điện thoại không hợp lệ!");
                    }
                }
                catch
                {
                    //Thông báo nếu bắt lỗi việc thêm sinh viên
                    MessageBox.Show("Lỗi thêm vào!Dữ liệu thêm vào sai!");
                }
            });

            //Command việc xóa sinh viên
            XoaCommand_SinhVien = new RelayCommand<object>((p) =>
            {
                return _TrangThaiThem_SinhVien == false && MaSV_SinhVien != "";
            }, (p) =>
            {
                //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng SinhVien
                //Với điều kiện mã sinh viên trong bảng SinhVien bằng MaSV_SinhVien và gán nó vào biến sv kiểu SinhVien
                SinhVien sv = db.SinhViens.Single(x => x.MaSV.ToString() == MaSV_SinhVien);
                //Xóa sinh viên
                db.SinhViens.DeleteOnSubmit(sv);
                //Cập nhật thay đổi trong bảng SinhVien
                db.SubmitChanges();
                //Thông báo xóa thành công
                MessageBox.Show("Xóa thành công!");
                //Gán các giá trị thuộc tính bằng rỗng
                //Thuộc tính NgaySinh_SinhVien = null
                MaSV_SinhVien = "";
                HoDem_SinhVien = "";
                Ten_SinhVien = "";
                MaLop_SinhVien = "";
                GioiTinh_SinhVien = "";
                NgaySinh_SinhVien = null;
                QueQuan_SinhVien = "";
                SoDT_SinhVien = "";
                DanhSach_SinhVien = new ObservableCollection<SinhVien>(db.SinhViens);
            });

            //Command thực hiện lệnh in,sử dụng grid trên window để in
            //Command Parameter là Grid để in 
            PrintCommand_BangDiem = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                //Tạo đối tượng printDialog thuộc lớp PrintDialog
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    //In đối tượng được truyền vào(Grid)
                    printDialog.PrintVisual(p, "Window Printing");
                }
            });

            //Command thực hiện xuất thông tin của sinh viên nếu sinh viên đó tồn tại trong database
            KiemTraSVCommand_Diem = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //Bắt lỗi khi truy vấn dữ liệu Linq
                try
                {
                    //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng SinhVien
                    //Với điều kiện mã sinh viên trong bảng SinhVien bằng MaSVTK_Diem và gán nó vào biến sv kiểu SinhVien
                    //Nếu không có sẽ báo lỗi và bắt lỗi ấy xuất ra thông báo
                    SinhVien sv = db.SinhViens.Single(x => x.MaSV.ToString() == MaSVTK_Diem);
                    MaSV_Diem = sv.MaSV.ToString();
                    HoTen_Diem = sv.HoDem + " " + sv.Ten;
                    MaLop_Diem = sv.MaLop;
                }
                catch
                {
                    //Thông báo lỗi mã sinh viên không tồn tại
                    MessageBox.Show("Mã sinh viên không tồn tại");
                }

            });

            //Command thực hiện xuất thông tin của học phần và điểm
            KiemTraHPCommand_Diem = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //Nếu MaHP_Diem chưa có dữ liệu sẽ thông báo người dùng nhập mã hp trên TextBox(txbMaSVTK_Diem)
                if (MaHPTK_Diem == null)
                {
                    MessageBox.Show("Vui lòng nhập mã Học phần");
                }
                //Nếu MaSV_Diem chưa có dữ liệu sẽ thông báo người dùng nhập mã sv trên TextBox(txbMaHPTK_Diem)
                else if (MaSV_Diem == null)
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên");
                }
                else
                {
                    //Bắt lỗi khi truy vấn dữ liệu
                    try
                    {
                        //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng HocPhan
                        //Với điều kiện mã học phần trong bảng HocPhan bằng MaHPTK_Diem và gán nó vào biến hp kiểu HocPhan
                        //Nếu không có sẽ thông báo lỗi 
                        HocPhan hp = db.HocPhans.Single(x => x.MaHP == MaHPTK_Diem);
                        MaHP_Diem = hp.MaHP;
                        TenHP_Diem = hp.TenHP;
                        SoTC_Diem = hp.SoTC.ToString();
                        try
                        {
                            //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng BangDiem
                            //Với điều kiện mã sinh viên bằng MaSV_Diem và mã học phần bằng MaHP_Diem
                            BangDiem bd = db.BangDiems.Single(x => x.MaSV.ToString() == MaSV_Diem && x.MaHP == MaHP_Diem);
                            //In các điểm nếu truy vấn thành công
                            DiemCC_Diem = (float)bd.DiemCC;
                            DiemGK_Diem = (float)bd.DiemGK;
                            DiemCK_Diem = (float)bd.DiemCK;
                            //Thuộc tính DaNhapDiem = true để thông báo người dùng môn này đã nhập điểm
                            DaNhapDiem = true;
                        }
                        catch
                        {
                            //Nếu không có sẽ đưa thuộc tính DaNhapDiem = false để thông báo người dùng môn này chưa nhập điểm
                            DaNhapDiem = false;
                            //Gán các giá trị điểm bằng 0
                            DiemCC_Diem = 0;
                            DiemGK_Diem = 0;
                            DiemCK_Diem = 0;
                        }
                    }
                    catch
                    {
                        //Thông báo mã học phần nhập không tồn tại
                        MessageBox.Show("Mã học phần không tồn tại!");
                    }
                    //In thông tin báo cho người dùng biết học phần này nhập điểm chưa?
                    ThongTinNhapDiem_Diem = DaNhapDiem ? "Đã nhập điểm trước đó!Có thể sửa điểm!" : "Chưa nhập điểm môn này!";
                }
            });

            //Command thực hiện việc nhập điểm
            NhapDiemCommand_Diem = new RelayCommand<object>((p) =>
            {
                //Với điều kiện môn này chưa nhập điểm
                //MaSV_Diem và MaHP_Diem khác null để nhập điểm
                return DaNhapDiem == false && MaSV_Diem != null && MaHP_Diem != null;
            }, (p) =>
            {
                //Kiểm tra các điểm từ 0 đến 10,nếu điểm dưới 0 hoặc lớn hơn 10 thì thông báo
                if (DiemCC_Diem < 0 || DiemGK_Diem < 0 || DiemCK_Diem < 0 ||
                    DiemCC_Diem >= 11 || DiemGK_Diem >= 11 || DiemCK_Diem >= 11)
                {
                    MessageBox.Show("Điếm nhập vào phải lớn hơn 0 và nhỏ hơn hoặc bằng 10");
                }
                else
                {
                    //Tạo biến bd kiểu BangDiem để lưu giá trị tất cả thuộc tính của BangDiem
                    BangDiem bd = new BangDiem
                    {
                        MaSV = (long)Convert.ToUInt64(MaSV_Diem),
                        MaHP = MaHP_Diem,
                        DiemCC = DiemCC_Diem,
                        DiemGK = DiemGK_Diem,
                        DiemCK = DiemCK_Diem
                    };
                    //Thêm sinh viên mới vào bảng BangDiem và cập nhật thay đổi
                    db.BangDiems.InsertOnSubmit(bd);
                    db.SubmitChanges();
                    //Gán DaNhapDiem = true để đánh dấu môn này đã nhập điểm 
                    DaNhapDiem = true;
                    //Thông báo nhập điểm thành công
                    MessageBox.Show("Đã thêm điểm");
                }
            });

            //Command thực hiện sửa điểm 
            SuaDiemCommand_Diem = new RelayCommand<object>((p) =>
            {
                //Điều kiện là DaNhapDiem = true(đã nhập điểm và đã lưu trên database)
                //MaSV_Diem và MaHP_Diem khác null để nhập điểm
                return DaNhapDiem && MaSV_Diem != null && MaHP_Diem != null;
            }, (p) =>
            {
                //Kiểm tra các điểm từ 0 đến 10,nếu điểm dưới 0 hoặc lớn hơn 10 thì thông báo
                if (DiemCC_Diem < 0 || DiemGK_Diem < 0 || DiemCK_Diem < 0 ||
                    DiemCC_Diem >= 11 || DiemGK_Diem >= 11 || DiemCK_Diem >= 11)
                {
                    MessageBox.Show("Điếm nhập vào phải lớn hơn 0 và nhỏ hơn hoặc bằng 10");
                }
                else
                {
                    //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng BangDiem
                    //Với điều kiện mã sinh viên bằng MaSV_Diem và mã học phần bằng MaHP_Diem
                    BangDiem bd = db.BangDiems.Single(x => x.MaSV.ToString() == MaSV_Diem && x.MaHP == MaHP_Diem);
                    //Thực hiện sửa các thông tin về điểm
                    bd.DiemCC = DiemCC_Diem;
                    bd.DiemGK = DiemGK_Diem;
                    bd.DiemCK = DiemCK_Diem;
                    //Cập nhật lại thay đổi và thông báo sửa thành công
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                }
            });

            //Command thực hiện xóa điểm trên học phần
            XoaDiemCommand_Diem = new RelayCommand<object>((p) =>
            {
                //Điều kiện là DaNhapDiem = true(đã nhập điểm và đã lưu trên database)
                //MaSV_Diem và MaHP_Diem khác null để nhập điểm
                return DaNhapDiem && MaSV_Diem != null && MaHP_Diem != null;
            }, (p) =>
            {
                //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng BangDiem
                //Với điều kiện mã sinh viên bằng MaSV_Diem và mã học phần bằng MaHP_Diem
                BangDiem bd = db.BangDiems.Single(x => x.MaSV.ToString() == MaSV_Diem && x.MaHP == MaHP_Diem);
                //Xóa điểm học phần đó
                db.BangDiems.DeleteOnSubmit(bd);
                //Cập nhật thay đổi trong bảng BangDiem
                db.SubmitChanges();
                //Gán các giá trị điểm bằng 0
                DiemCC_Diem = 0;
                DiemGK_Diem = 0;
                DiemCK_Diem = 0;
                //Thuộc tính DaNhapDiem = false thể hiện học phần đó chưa nhập điểm
                DaNhapDiem = false;
                //Thông báo xóa thành công
                MessageBox.Show("Xóa thành công");
            });

            //Command thực hiện việc cập nhật lại thông tin học phần
            CapNhatCommand_HocPhan = new RelayCommand<object>((p) =>
            {
                //Điều kiện _TrangThaiThem_HocPhan == false
                //SelectedItem_HocPhan khác null tức là chưa chọn được dữ liệu trong DataGrid dgDanhSachHocPhan
                return _TrangThaiThem_HocPhan == false && SelectedItem_HocPhan != null;
            }, (p) =>
            {
                //Kiểm tra nếu Số tín chỉ của học phần bé hơn 0
                //Hoặc tên học phần bằng rỗng thì thông báo
                if (Convert.ToInt32(SoTC_HocPhan) <= 0 || TenHP_HocPhan == "")
                {
                    MessageBox.Show("Số học phần phải lớn hơn 0 hoặc bị trống tên học phần!");
                }
                else
                {
                    //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng HocPhan
                    //Với điều kiện mã học phần bằng MaHP_HocPhan
                    HocPhan hp = db.HocPhans.Single(x => x.MaHP == MaHP_HocPhan);
                    //Sửa các thông tin theo yêu cầu
                    hp.TenHP = TenHP_HocPhan;
                    hp.SoTC = Convert.ToInt32(SoTC_HocPhan);
                    //Cập nhật lại thay đổi trong bảng HocPhan và thông báo sửa thành công
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                }
            });

            //Command thực hiện xóa học phần
            XoaCommand_HocPhan = new RelayCommand<object>((p) =>
            {
                //Điều kiện _TrangThaiThem_HocPhan == false
                //SelectedItem_HocPhan khác null tức là chưa chọn được dữ liệu trong DataGrid dgDanhSachHocPhan
                return _TrangThaiThem_HocPhan == false && SelectedItem_HocPhan != null;
            }, (p) =>
            {
                //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng HocPhan
                //Với điều kiện mã học phần bằng MaHP_HocPhan
                HocPhan hp = db.HocPhans.Single(x => x.MaHP == MaHP_HocPhan);
                //Xóa học phần đó trong bảng HocPhan
                db.HocPhans.DeleteOnSubmit(hp);
                //Cập nhật thay đổi trong bảng HocPhan
                db.SubmitChanges();
                //Gán các thuộc tính bằng rỗng thể hiện học phần đã xóa
                MaHP_HocPhan = "";
                TenHP_HocPhan = "";
                SoTC_HocPhan = "";
                //Thông báo xóa thành công và đổ lại dữ liệu
                MessageBox.Show("Xóa thành công");
                DanhSach_HocPhan = new ObservableCollection<HocPhan>(db.HocPhans);
            });

            //Command thực hiện việc làm trống các thuộc tính để thêm học phần
            //Command Parameter là btnOK để hiện button OK_HocPhan
            ThemCommand_HocPhan = new RelayCommand<Button>((p) =>
            {
                //Điều kiện để thực thi là _TrangThaiThem_HocPhan == false
                return _TrangThaiThem_HocPhan == false;
            }, (p) =>
            {
                //Hiện lại Button OK trên TabItem Diem_HocPhan,do Command Parameter truyền vào
                p.Visibility = Visibility.Visible;
                //Gán _TrangThaiThem_HocPhan = true để thực hiện việc thêm học phần
                //Các button btnCapNhatHocPhan,btnXoaHocPhan,btnThemHocPhan sẽ không thể thực hiện
                _TrangThaiThem_HocPhan = true;
                //Làm trống các thuộc tính
                MaHP_HocPhan = "";
                TenHP_HocPhan = "";
                SoTC_HocPhan = "";
            });

            //Command thực hiện việc thêm sinh viên
            //Command Parameter là btnOK để ẩn button OK_HocPhan
            OKCommand_HocPhan = new RelayCommand<Button>((p) =>
            {
                //Điều kiện để thực thi là _TrangThaiThem_HocPhan == true thì mới thêm học phần
                return _TrangThaiThem_HocPhan;
            }, (p) =>
            {
                //Kiểm tra nếu Số tín chỉ của học phần bé hơn 0
                //Hoặc tên học phần bằng rỗng thì thông báo
                if (Convert.ToInt32(SoTC_HocPhan) <= 0 || TenHP_HocPhan == "")
                {
                    MessageBox.Show("Số học phần phải lớn hơn 0 hoặc bị trống tên học phần!");
                }
                else
                {
                    //Kiểm tra mã học phần người dùng nhập có trùng trên bảng HocPhan hay không?
                    //Nếu trùng thì giá trị sẽ khác 0
                    if (db.HocPhans.Where(x => x.MaHP == MaHP_HocPhan).Count() == 0)
                    {
                        //Tạo biến hp kiểu HocPhan để lưu giá trị tất cả thuộc tính của HocPhan
                        HocPhan hp = new HocPhan
                        {
                            MaHP = MaHP_HocPhan,
                            TenHP = TenHP_HocPhan,
                            SoTC = Convert.ToInt32(SoTC_HocPhan)
                        };
                        //Thêm học phần vào trong bảng HocPhan
                        db.HocPhans.InsertOnSubmit(hp);
                        //Cập nhật thay đổi trong bảng HocPhan và thông báo thêm thành công
                        db.SubmitChanges();
                        MessageBox.Show("Thêm học phần thành công!");
                        //Đổ lại dữ liệu
                        DanhSach_HocPhan = new ObservableCollection<HocPhan>(db.HocPhans);
                        //_TrangThaiThem_HocPhan = false và ẩn lại button OK_HocPhan
                        _TrangThaiThem_HocPhan = false;
                        p.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        //Thông báo trùng mã học phần
                        MessageBox.Show("Trùng mã học phần!");
                    }
                }
            });

            //Command bắt sự kiện PasswordChanged ở pwbMatKhauCu khi người dùng nhập mật khẩu ở pwbMatKhauCu
            //CommandParameter truyền vào là pwbMatKhauCu để lấy mật khẩu lưu vào thuộc tính MatKhauCu_Info
            PasswordChangedCommand_MatKhauCu_Info = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                MatKhauCu_Info = p.Password;
            });


            //Command bắt sự kiện PasswordChanged ở pwbMatKhauMoi khi người dùng nhập mật khẩu ở pwbMatKhauMoi
            //CommandParameter truyền vào là pwbMatKhauCu để lấy mật khẩu lưu vào thuộc tính MatKhauMoi_Info
            PasswordChangedCommand_MatKhauMoi_Info = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                MatKhauMoi_Info = p.Password;
            });

            //Command bắt sự kiện PasswordChanged ở pwbNhapLaiMK khi người dùng nhập mật khẩu ở pwbNhapLaiMK
            //CommandParameter truyền vào là pwbNhapLaiMK để lấy mật khẩu lưu vào thuộc tính NhapLaiMK_Info
            PasswordChangedCommand_NhapLaiMK_Info = new RelayCommand<PasswordBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                NhapLaiMK_Info = p.Password;
            });


            //Command thực hiện cập nhật lại thông tin tài khoản
            CapNhatCommand_Info = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Bắt lỗi nếu có vấn đề về nhập dữ liệu
                try
                {
                    //Kiểm tra điều kiện nếu số điện thoại có 10 số và chuyển được sang dạng số
                    if (SoDT_Info.ToString().Length == 10 && int.TryParse(SoDT_Info, out int numValue))
                    {
                        //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng TaiKhoan
                        //Với điều kiện tên tài khoản bằng TenTaiKhoan_Info
                        TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan_Info);
                        //Sửa các thông tin theo yêu cầu
                        tk.HoDem = HoDem_Info;
                        tk.Ten = Ten_Info;
                        tk.GioiTinh = GioiTinh_Info;
                        tk.NgaySinh = (DateTime)NgaySinh_Info;
                        tk.QueQuan = QueQuan_Info;
                        tk.SoDT = SoDT_Info;
                        //Cập nhật thay đổi trong bảng TaiKhoan và thông báo sửa thành công
                        db.SubmitChanges();
                        MessageBox.Show("Sửa thành công!");
                    }
                    else
                    {
                        //Thông báo lỗi nhập về số điện thoại
                        MessageBox.Show("Số điện thoại phải 10 số hoặc dữ liệu số điện thoại không hợp lệ!");
                    }
                }
                catch
                {
                    //Thông báo về việc lỗi nhập dữ liệu
                    MessageBox.Show("Lỗi nhập dữ liệu!");
                }
            });

            //Command thực hiện đổi mật khẩu tài khoản
            DoiMatKhauCommand_Info = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Bắt lỗi trong việc truy vấn dữ liệu Linq khi truy vấn dữ liệu không có kết quả
                try
                {
                    //Câu lệnh truy vấn Linq lấy duy nhất 1 phần tử từ bảng TaiKhoan
                    //Với điều kiện tên tài khoản bằng TenTaiKhoan_Info
                    //Và mật khẩu bằng MatKhauCu_Info
                    TaiKhoan tk = db.TaiKhoans.Single(x => x.TenTK == TenTaiKhoan_Info && x.MatKhau == MatKhauCu_Info);
                    //Kiểm tra mật khẩu mới trùng với nhập lại mật khẩu
                    if (MatKhauMoi_Info == NhapLaiMK_Info)
                    {
                        //Sửa lại dữ liệu MatKhau và cập nhật lại thay đổi
                        tk.MatKhau = MatKhauMoi_Info;
                        db.SubmitChanges();
                        //Thông báo đổi mật khẩu thành công
                        MessageBox.Show("Đổi mật khẩu thành công!");
                    }
                    else
                    {
                        //Nếu mật khẩu mới không trùng với giá trị Nhập lại mật khẩu
                        MessageBox.Show("Mật khẩu nhập lại không đúng!");
                    }
                }
                catch
                {
                    //Thông báo mật khẩu cũ nhập không đúng
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                }
            });

            //Command vào cửa sổ AdminView
            AdminCommand_Info = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //Kiểm tra TenTaiKhoan_Info là admin hay không,nếu có thì mở cửa sổ AdminView hiện Dialog
                //Ngược lại sẽ thông báo
                if (TenTaiKhoan_Info == "admin")
                {
                    AdminView adminView = new AdminView();
                    adminView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản admin mới được truy cập!");
                }
            });

            //Command thực hiện việc đăng xuât tài khoản và thoát cửa số ManagerView
            //Command Parameter chính là managerView để đóng cửa sổ nó lại
            DangXuatCommand_Info = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                //Tạo đổi tượng loginView lớp LoginView và hiện cửa sổ LoginView
                LoginView loginView = new LoginView();
                loginView.Show();
                //Sau đó thoát cửa sổ ManagerView đi thông qua Command Parameter đã truyền vào
                p.Close();
            });

            //Command thực hiện việc thoát hẳn chương trình
            //Command Parameter chính là managerView để đóng cửa sổ nó lại,tương đương thoát chương trình
            ExitCommand_Info = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                //Thông qua Command Parameter truyền vào để thoát chương trình
                p.Close();
            });
        }
    }
}