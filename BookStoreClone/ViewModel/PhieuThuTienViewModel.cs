using BookStoreClone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreClone.ViewModel
{
    class PhieuThuTienViewModel : BaseViewModel
    {
        DateTime _SelectedDateTime;
        private CTHD _selectedItemCTHD;
        private Visibility _visibilityXemHoaDon;
        private HoaDon _SelectedHoaDon;
        private KhachHang _SelectedKhachHang;
        QuanLyKhachHangViewModel quanLyKhachHangViewModel;
        Visibility visibilityPnlThuTien;
        public Visibility VisibilityXemHoaDon { get => _visibilityXemHoaDon; set { _visibilityXemHoaDon = value; OnPropertyChanged(); } }
        string soTienTra;
        public ICommand XacNhanThuTienCommand { get; set; }
        public HoaDon SelectedHoaDon
        { get => _SelectedHoaDon; set
            { _SelectedHoaDon = value; OnPropertyChanged();
                if (SelectedHoaDon == null)
                {
                    VisibilityXemHoaDon = Visibility.Collapsed;
                    return;
                }
                else VisibilityXemHoaDon = Visibility.Visible;
                foreach (CTHD hd in SelectedHoaDon.CTHDs)
                {
                    if (hd.PhuongThuc == null)
                        hd.PhuongThuc = "Mua";
                    if (hd.PhuongThuc == "Mượn")
                        if (hd.TrangThai == null)
                            hd.TrangThai = "Đã trả";
                }
                return;
            }
        }

        public ICommand GetViewModelQuanLyKhachHang { get; set; }
        public ICommand TraSach { get; set; }
        public Visibility VisibilityPnlThuTien { get => visibilityPnlThuTien; set { visibilityPnlThuTien = value; OnPropertyChanged(); } }
        public string SoTienTra { get => soTienTra; set { soTienTra = value; OnPropertyChanged(); } }
        public KhachHang SelectedKhachHang { get => _SelectedKhachHang; set { _SelectedKhachHang = value; OnPropertyChanged();
                if (SelectedKhachHang == null)
                    return;
                if (SelectedKhachHang.SoTienNo > 0)
                    VisibilityPnlThuTien = Visibility.Visible;
                else VisibilityPnlThuTien = Visibility.Collapsed;
                SelectedKhachHang.SoTienPhat = 0;
                foreach(HoaDon hd in SelectedKhachHang.HoaDons) 
                    foreach(CTHD cthd in hd.CTHDs) 
                    {
                        TimeSpan Time = ((TimeSpan)(SelectedDateTime - hd.NgayBan));
                        int TongSoNgay = Time.Days;
                        if (cthd.TrangThai == "Chưa trả")
                            if (TongSoNgay > 30)
								SelectedKhachHang.SoTienPhat += (int)cthd.ThanhTien*TongSoNgay/30;
					}
                        
                
            
            } }

        public DateTime SelectedDateTime { get => _SelectedDateTime; set { _SelectedDateTime = value; OnPropertyChanged(); } }

        public PhieuThuTienViewModel()
        {
            SelectedDateTime = System.DateTime.Now;
            VisibilityXemHoaDon = Visibility.Collapsed;
            XacNhanThuTienCommand = new RelayCommand<Button>((p) => {
                if (p == null) return false;
                p.IsEnabled = false;

                if (SelectedKhachHang == null) return false;

                if (KiemTraSo(SoTienTra) == false) return false;

                if (int.Parse(soTienTra) > SelectedKhachHang.SoTienNo || int.Parse(soTienTra) <= 0) return false;

                p.IsEnabled = true;
                return true;
            }, (p) =>
            {
                DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhieuThuTien] ON");
                DataProvider.Ins.DB.PhieuThuTiens.Add(new PhieuThuTien() { KhachHang = SelectedKhachHang, SoTienThu = int.Parse(soTienTra), NguoiDung = DataProvider.Ins.DB.NguoiDungs.Where(x => x.TenDangNhap == Const.IDNguoiDung).First(), NgayThuTien = SelectedDateTime });
                DataProvider.Ins.DB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[PhieuThuTien] OFF");
                SelectedKhachHang.SoTienNo -= int.Parse(soTienTra);
                DataProvider.Ins.DB.SaveChanges();
                int idKhach = SelectedKhachHang.MaKH;
                SelectedKhachHang = new KhachHang();
                SelectedKhachHang = DataProvider.Ins.DB.KhachHangs.Where(x => x.MaKH == idKhach).First();
                SoTienTra = "";
                quanLyKhachHangViewModel.TimKiemKhachHang();
                SelectedDateTime = System.DateTime.Now;
            });
            GetViewModelQuanLyKhachHang = new RelayCommand<DockPanel>((p) => {

                return true;
            }, (p) =>
            {
                quanLyKhachHangViewModel = p.DataContext as QuanLyKhachHangViewModel;
            });
            TraSach = new RelayCommand<Button>((p) => {
                if (SelectedItemCTHD == null)
                    return false;

                return true; 

                return false;
        }, (p) =>
            {
                if (SelectedItemCTHD.PhuongThuc == "Mượn")
                    if (SelectedItemCTHD.TrangThai == "Chưa trả")
                    {
                        SelectedItemCTHD.TrangThai = "Đã trả";
                        SelectedItemCTHD.Sach.SoLuongTon += SelectedItemCTHD.SoLuong;
                        SelectedKhachHang.SoTienNo += SelectedKhachHang.SoTienPhat;
                        SelectedKhachHang.SoTienPhat = 0;
                    }
            });

        }
        public CTHD SelectedItemCTHD
        {
            get => _selectedItemCTHD;
            set
            {
                _selectedItemCTHD = value;
                OnPropertyChanged();
                if (SelectedItemCTHD == null)
                    return;
            }
        }
        private bool KiemTraSo(string str)
        {
            try
            {
                int.Parse(str);
                return true;
            }
            catch { return false; }
        }
    }
}
