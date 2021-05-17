using ticketAPI.Dtos;
using ticketAPI.Entities;

namespace ticketAPI
{
    public static class Extensions
    {
        public static VeVMDto AsDto(this VeVM item){
            return new VeVMDto {
                maGhe = item.maGhe,
                giaVe = item.giaVe,
            };
        }

        public static DatVeDto AsDto(this DanhSachVeDat danhSachVeDat){
            return new DatVeDto {
                maLichChieu = danhSachVeDat.maLichChieu,
                danhSachVe = danhSachVeDat.danhSachVe,
                taiKhoanNguoiDung = danhSachVeDat.taiKhoanNguoiDung
            };
        }

        public static LichChieuInsertDto AsDto(this LichChieuInsert lichChieuInsert){
            return new LichChieuInsertDto {
                maPhim = lichChieuInsert.maPhim,
                ngayChieuGioChieu = lichChieuInsert.ngayChieuGioChieu,
                maRap = lichChieuInsert.maRap,
                giaVe = lichChieuInsert.giaVe
            };
        }

        public static LoaiNguoiDungDto AsDto(this LoaiNguoiDung loaiNguoiDung){
            return new LoaiNguoiDungDto{
                maLoaiNguoiDung = loaiNguoiDung.maLoaiNguoiDung,
                tenLoai = loaiNguoiDung.tenLoai
            };
        }

        public static LayDanhSachNguoiDungDto AsDto(this NguoiDungVM nguoiDungVM){
            return new LayDanhSachNguoiDungDto{
                taiKhoan = nguoiDungVM.taiKhoan,
                matKhau = nguoiDungVM.matKhau,
                email = nguoiDungVM.email,
                soDt = nguoiDungVM.soDt,
                maLoaiNguoiDung = nguoiDungVM.maLoaiNguoiDung,
                hoTen = nguoiDungVM.hoTen
            };
        }

        public static LayDanhSachNguoiDungPhanTrangDto AsDto(this LayDanhSachNguoiDungPhanTrangDto nguoiDungVM){
            return new LayDanhSachNguoiDungPhanTrangDto{
                currentPage = nguoiDungVM.currentPage,
                count = nguoiDungVM.count,
                totalPages = nguoiDungVM.totalPages,
                totalCount = nguoiDungVM.totalCount,
                items = nguoiDungVM.items
            };
        }

        public static DangNhapDto AsDto(this DangNhapDto dangNhap){
            return new DangNhapDto {
                taiKhoan = dangNhap.taiKhoan,
                email = dangNhap.email,
                soDt = dangNhap.soDt,
                maLoaiNguoiDung = dangNhap.maLoaiNguoiDung,
                hoTen = dangNhap.hoTen,
                maNhom = dangNhap.maNhom,
                accessToken = dangNhap.accessToken
            };
        }

        public static DangKyDto AsDto(this DangKyDto dangKy){
            return new DangKyDto {
                taiKhoan = dangKy.taiKhoan,
                matKhau = dangKy.matKhau,
                email = dangKy.email,
                soDt = dangKy.soDt,
                maLoaiNguoiDung = dangKy.maLoaiNguoiDung,
                hoTen = dangKy.hoTen,
                maNhom = dangKy.maNhom
            };
        }

        public static LayDanhSachPhimDto AsDto(this PhimInsert layDanhSachPhim){
            return new LayDanhSachPhimDto{
                maPhim = layDanhSachPhim.maPhim,
                tenPhim = layDanhSachPhim.tenPhim,
                biDanh = layDanhSachPhim.biDanh,
                trailer = layDanhSachPhim.trailer,
                hinhAnh = layDanhSachPhim.hinhAnh,
                moTa = layDanhSachPhim.moTa,
                maNhom = layDanhSachPhim.maNhom,
                ngayKhoiChieu =layDanhSachPhim.ngayKhoiChieu,
                danhGia = layDanhSachPhim.danhGia
            };
        }

        public static LayDanhSachPhimPhanTrangDto AsDto(this LayDanhSachPhimPhanTrangDto phimPhanTrangDto){
            return new LayDanhSachPhimPhanTrangDto{
                currentPage = phimPhanTrangDto.currentPage,
                count = phimPhanTrangDto.count,
                totalPages = phimPhanTrangDto.totalPages,
                totalCount = phimPhanTrangDto.totalCount,
                items = phimPhanTrangDto.items
            };
        }

        public static ThemPhimDto AsDto(this ThemPhimDto themPhimDto){
            return new ThemPhimDto{
                maPhim = themPhimDto.maPhim,
                tenPhim = themPhimDto.tenPhim,
                biDanh = themPhimDto.biDanh,
                trailer = themPhimDto.trailer,
                hinhAnh = themPhimDto.hinhAnh,
                moTa = themPhimDto.maNhom,
                maNhom = themPhimDto.maNhom,
                ngayKhoiChieu =themPhimDto.ngayKhoiChieu,
                danhGia = themPhimDto.danhGia
            };
        }

        

    }
}