using ticketAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ticketAPI.Dtos;

namespace ticketAPI.Repositories
{
    public class InMemQuanLyNguoiDungsRepository : IQuanLyNguoiDungsRepository
    {
        private readonly List<LoaiNguoiDung> danhSachLoaiNguoiDung = new(){
            new LoaiNguoiDung { maLoaiNguoiDung = "KhachHang", tenLoai = "Khách hàng" },
            new LoaiNguoiDung { maLoaiNguoiDung = "QuanTri", tenLoai = "Quản trị" }
        };

        private readonly List<NguoiDungVM> danhSachNguoiDung = new(){
            new NguoiDungVM {
                taiKhoan = "1122",
                hoTen = "Abc",
                email = "abc@gmail.com",
                soDt = "0987654321",
                maNhom = "GP01",
                matKhau = "123456",
                maLoaiNguoiDung = "KhachHang",
                accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTEyMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IktoYWNoSGFuZyIsIm5iZiI6MTYyMDY0ODU5OCwiZXhwIjoxNjIwNjUyMTk4fQ.gsNMojs6kPC2CD5YPLF93htU8teP_mx3tlwMz_iCHkE"
            },
            new NguoiDungVM {
                taiKhoan = "1133",
                hoTen = "Def",
                email = "def@gmail.com",
                soDt = "0987654322",
                maNhom = "GP01",
                matKhau = "123456",
                maLoaiNguoiDung = "QuanTri",
                accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTEyMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IktoYWNoSGFuZyIsIm5iZiI6MTYyMDY0ODU5OCwiZXhwIjoxNjIwNjUyMTk4fQ.gsNMojs6kPC2CD5YPLF93htU8teP_mx3tlwMz_iCHkE"
            }
        };


        private readonly List<LayDanhSachNguoiDungPhanTrangDto> danhSachNguoiDungPhanTrang = new(){
            new LayDanhSachNguoiDungPhanTrangDto {
                currentPage = 1,
                count = 20,
                totalPages = 30,
                totalCount = 613,
                items = new() {
                    new NguoiDungVM {
                        taiKhoan = "1122",
                        hoTen = "Abc",
                        email = "abc@gmail.com",
                        soDt = "0987654321",
                        maNhom = "GP01",
                        matKhau = "123456",
                        maLoaiNguoiDung = "KhachHang",
                        accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTEyMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IktoYWNoSGFuZyIsIm5iZiI6MTYyMDY0ODU5OCwiZXhwIjoxNjIwNjUyMTk4fQ.gsNMojs6kPC2CD5YPLF93htU8teP_mx3tlwMz_iCHkE"
                    },
                    new NguoiDungVM {
                        taiKhoan = "1133",
                        hoTen = "Def",
                        email = "def@gmail.com",
                        soDt = "0987654322",
                        maNhom = "GP01",
                        matKhau = "123456",
                        maLoaiNguoiDung = "QuanTri",
                        accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMTEyMiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IktoYWNoSGFuZyIsIm5iZiI6MTYyMDY0ODU5OCwiZXhwIjoxNjIwNjUyMTk4fQ.gsNMojs6kPC2CD5YPLF93htU8teP_mx3tlwMz_iCHkE"
                    }
                }
            }
        };

        public void CapNhatThongTinNguoiDung(NguoiDungVM nd, string Authorization)
        {
            var index = danhSachNguoiDung.FindIndex(existingNgDung => existingNgDung.taiKhoan == nd.taiKhoan);
            nd.accessToken = Authorization;
            danhSachNguoiDung[index] = nd;
        }

        public void DangKy(NguoiDungVM nd)
        {
            danhSachNguoiDung.Add(nd);
        }

        public DangNhapDto DangNhap(ThongTinDangNhapVM ndDN)
        {
            DangNhapDto dangNhapDto = new DangNhapDto();
            foreach ( NguoiDungVM nguoiDung in danhSachNguoiDung){
                if(nguoiDung.taiKhoan.ToString() == ndDN.taiKhoan && nguoiDung.matKhau.ToString()== ndDN.matKhau){
                    dangNhapDto.taiKhoan = nguoiDung.taiKhoan;
                    dangNhapDto.email = nguoiDung.email;
                    dangNhapDto.soDt = nguoiDung.soDt;
                    dangNhapDto.maNhom = nguoiDung.maNhom;
                    dangNhapDto.maLoaiNguoiDung = nguoiDung.maLoaiNguoiDung;
                    dangNhapDto.accessToken = nguoiDung.accessToken;
                }
            }
            return dangNhapDto;
        }

        public List<LoaiNguoiDung> LayDanhSachLoaiNguoiDung()
        {
            return danhSachLoaiNguoiDung;
        }

        public List<NguoiDungVM> LayDanhSachNguoiDung(string tuKhoa, string maNhom = "GP01")
        {
            List<NguoiDungVM> dsNguoiDung = new List<NguoiDungVM>();
            foreach ( NguoiDungVM nguoiDung in danhSachNguoiDung){
                if(nguoiDung.taiKhoan.ToString().Contains(tuKhoa) && nguoiDung.maNhom.ToString()=="GP01"){
                    dsNguoiDung.Add(nguoiDung);
                }
            }
            return dsNguoiDung;
        }

        public LayDanhSachNguoiDungPhanTrangDto LayDanhSachNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1)
        {
            LayDanhSachNguoiDungPhanTrangDto danhSachNguoiDungPhanTrang = new LayDanhSachNguoiDungPhanTrangDto();
            foreach ( NguoiDungVM nguoiDung in danhSachNguoiDung){
                if(nguoiDung.taiKhoan.ToString().Contains(tuKhoa) && nguoiDung.maNhom.ToString()=="GP01"){
                    danhSachNguoiDungPhanTrang.items.Add(nguoiDung);
                }
            }
            return danhSachNguoiDungPhanTrang;
        }

        public NguoiDungVM LayNguoiDung(string taiKhoan)
        {
            return danhSachNguoiDung.Where(item => item.taiKhoan == taiKhoan).SingleOrDefault();
        }

        public void ThemNguoiDung(NguoiDungVM nd)
        {
            danhSachNguoiDung.Add(nd);
        }

        public List<NguoiDungVM> TimKiemNguoiDung(string tuKhoa, string maNhom = "GP01")
        {
            List<NguoiDungVM> dsNguoiDung = new List<NguoiDungVM>();
            foreach ( NguoiDungVM nguoiDung in danhSachNguoiDung){
                if( ( nguoiDung.taiKhoan.ToString().Contains(tuKhoa) || nguoiDung.hoTen.ToString().Contains(tuKhoa)
                        || nguoiDung.email.ToString().Contains(tuKhoa) || nguoiDung.soDt.ToString().Contains(tuKhoa) )
                        && nguoiDung.maNhom.ToString()=="GP01"){
                    dsNguoiDung.Add(nguoiDung);
                }
            }
            return dsNguoiDung;
        }

        public LayDanhSachNguoiDungPhanTrangDto TimKiemNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1)
        {
            LayDanhSachNguoiDungPhanTrangDto danhSachNguoiDungPhanTrang = new LayDanhSachNguoiDungPhanTrangDto();
            foreach ( NguoiDungVM nguoiDung in danhSachNguoiDung){
                if(( nguoiDung.taiKhoan.ToString().Contains(tuKhoa) || nguoiDung.hoTen.ToString().Contains(tuKhoa)
                        || nguoiDung.email.ToString().Contains(tuKhoa) || nguoiDung.soDt.ToString().Contains(tuKhoa) )
                        && nguoiDung.maNhom.ToString()=="GP01"){
                    danhSachNguoiDungPhanTrang.items.Add(nguoiDung);
                }
            }
            return danhSachNguoiDungPhanTrang;
        }

        public void XoaNguoiDung(string taiKhoan)
        {
            var index = danhSachNguoiDung.FindIndex(existingNgDung => existingNgDung.taiKhoan == taiKhoan);
            danhSachNguoiDung.RemoveAt(index);
        }
    }
}