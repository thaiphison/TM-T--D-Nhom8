using System.Collections.Generic;
using ticketAPI.Entities;
using ticketAPI.Dtos;

namespace ticketAPI.Repositories
{
    public interface IQuanLyPhimsRepository
    {
        List<PhimInsert> LayDanhSachPhim(string tenPhim, string maNhom = "GP01");

        PhimInsert LayPhim(int maPhim);

        LayDanhSachPhimPhanTrangDto LayDanhSachPhimPhanTrang(string tenPhim, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1);

        void ThemPhIM(PhimInsert nd);

         void CapNhatPhim(PhimInsert nd);

         void XoaPhim(int maPhim);
    }
}