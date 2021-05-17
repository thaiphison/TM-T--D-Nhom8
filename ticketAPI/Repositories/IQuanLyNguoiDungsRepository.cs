using System.Collections.Generic;
using ticketAPI.Entities;
using ticketAPI.Dtos;

namespace ticketAPI.Repositories
{
    public interface IQuanLyNguoiDungsRepository
    {
        List<LoaiNguoiDung> LayDanhSachLoaiNguoiDung();

        List<NguoiDungVM> LayDanhSachNguoiDung(string tuKhoa, string maNhom = "GP01");

        NguoiDungVM LayNguoiDung(string taiKhoan);

        LayDanhSachNguoiDungPhanTrangDto LayDanhSachNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1);
    
        List<NguoiDungVM> TimKiemNguoiDung(string tuKhoa, string maNhom = "GP01");

        LayDanhSachNguoiDungPhanTrangDto TimKiemNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1);

        DangNhapDto DangNhap(ThongTinDangNhapVM ndDN);

        void DangKy(NguoiDungVM nd);

        void ThemNguoiDung(NguoiDungVM nd);

        void CapNhatThongTinNguoiDung(NguoiDungVM nd, string Authorization );
        
        void XoaNguoiDung(string taiKhoan);
    }
}