using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ticketAPI.Repositories;
using ticketAPI.Entities;
using ticketAPI.Dtos;

namespace ticketAPI.Controllers
{
    [ApiController]
    [Route("api/QuanLyNguoiDung")]
    public class QuanLyNguoiDungController : ControllerBase
    {
        private readonly IQuanLyNguoiDungsRepository repository;

        public QuanLyNguoiDungController(IQuanLyNguoiDungsRepository repository){
            this.repository = repository;
        }

        [HttpGet("LayDanhSachLoaiNguoiDung")]
        public IEnumerable<LoaiNguoiDungDto> LayDanhSachLoaiNguoiDung(){
            var items = repository.LayDanhSachLoaiNguoiDung().Select(item =>item.AsDto());
            return items;
        }

        [HttpGet("LayDanhSachNguoiDung")]
        public IEnumerable<LayDanhSachNguoiDungDto> LayDanhSachNguoiDung(string tuKhoa, string maNhom = "GP01"){
            var item = repository.LayDanhSachNguoiDung(tuKhoa).Select(item => item.AsDto());
            return item;
        }

        [HttpGet("LayNguoiDung")]
        public ActionResult<LayDanhSachNguoiDungDto> LayNguoiDung(string taiKhoan){
            var item = repository.LayNguoiDung(taiKhoan);

            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpGet("LayDanhSachNguoiDungPhanTrang")]
        public ActionResult<LayDanhSachNguoiDungPhanTrangDto> LayDanhSachNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang =1, int soPhanTuTrenTrang = 1){
            var item = repository.LayDanhSachNguoiDungPhanTrang(tuKhoa, maNhom, soTrang, soPhanTuTrenTrang);
            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpGet("TimKiemNguoiDung")]
        public IEnumerable<LayDanhSachNguoiDungDto> TimKiemNguoiDung(string tuKhoa, string maNhom = "GP01"){
            var item = repository.TimKiemNguoiDung(tuKhoa).Select(item => item.AsDto());
            return item;
        }

        [HttpGet("TimKiemNguoiDungPhanTrang")]
        public ActionResult<LayDanhSachNguoiDungPhanTrangDto> TimKiemNguoiDungPhanTrang(string tuKhoa, string maNhom = "GP01", int soTrang =1, int soPhanTuTrenTrang = 1){
            var item = repository.TimKiemNguoiDungPhanTrang(tuKhoa, maNhom, soTrang, soPhanTuTrenTrang);
            if(item is null){
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost("DangNhap")]
        public ActionResult<DangNhapDto> DangNhap(ThongTinDangNhapVM ndDN){

            var item = repository.DangNhap(ndDN);
            return item.AsDto();

        }

        [HttpPost("DangKy")]
        public ActionResult<DangKyDto> DangKy(DangKyDto dangKyDto){
            NguoiDungVM nguoiDung = new(){
                taiKhoan = dangKyDto.taiKhoan,
                matKhau = dangKyDto.matKhau,
                email = dangKyDto.email,
                soDt = dangKyDto.soDt,
                maNhom = dangKyDto.maNhom,
                maLoaiNguoiDung = dangKyDto.maLoaiNguoiDung,
                hoTen = dangKyDto.hoTen
            };

            repository.DangKy(nguoiDung);
            return CreatedAtAction(nameof(LayDanhSachNguoiDung),
                new { taiKhoan = nguoiDung.taiKhoan,
                        matKhau = dangKyDto.matKhau,
                        email = dangKyDto.email,
                        soDt = dangKyDto.soDt,
                        maNhom = dangKyDto.maNhom,
                        maLoaiNguoiDung = dangKyDto.maLoaiNguoiDung,
                        hoTen = dangKyDto.hoTen
                    },
                nguoiDung.AsDto());
        }

        [HttpPost("ThemNguoiDung")]
        public ActionResult<DangKyDto> ThemNguoiDung(DangKyDto dangKyDto){
            NguoiDungVM nguoiDung = new(){
                taiKhoan = dangKyDto.taiKhoan,
                matKhau = dangKyDto.matKhau,
                email = dangKyDto.email,
                soDt = dangKyDto.soDt,
                maNhom = dangKyDto.maNhom,
                maLoaiNguoiDung = dangKyDto.maLoaiNguoiDung,
                hoTen = dangKyDto.hoTen
            };

            repository.ThemNguoiDung(nguoiDung);
            return CreatedAtAction(nameof(LayDanhSachNguoiDung),
                new { taiKhoan = nguoiDung.taiKhoan,
                        matKhau = dangKyDto.matKhau,
                        email = dangKyDto.email,
                        soDt = dangKyDto.soDt,
                        maNhom = dangKyDto.maNhom,
                        maLoaiNguoiDung = dangKyDto.maLoaiNguoiDung,
                        hoTen = dangKyDto.hoTen
                    },
                nguoiDung.AsDto());
        }


        [HttpPut("CapNhatThongTinNguoiDung")]
        public ActionResult CapNhatThongTinNguoiDung(NguoiDungVM nguoiDung, string Authorization){
            var existingNgDung = repository.LayNguoiDung(nguoiDung.taiKhoan);

            if(existingNgDung is null){
                return NotFound();
            }
            
            NguoiDungVM updatedNgDung = existingNgDung with {
                taiKhoan = nguoiDung.taiKhoan,
                matKhau = nguoiDung.matKhau,
                email = nguoiDung.email,
                soDt = nguoiDung.soDt,
                maNhom = nguoiDung.maNhom,
                maLoaiNguoiDung = nguoiDung.maLoaiNguoiDung,
                hoTen = nguoiDung.hoTen
            };

            repository.CapNhatThongTinNguoiDung(updatedNgDung, Authorization);

            return NoContent();
        }

        [HttpDelete("XoaNguoiDung")]
        public ActionResult XoaNguoiDung(string taiKhoan){
            var existingNgDung = repository.LayNguoiDung(taiKhoan);

            if(existingNgDung is null){
                return NotFound();
            }
            
            repository.XoaNguoiDung(taiKhoan);

            return NoContent();
        }
    

    }
}