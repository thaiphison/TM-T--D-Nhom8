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
    [Route("api/QuanLyPhim")]
    public class QuanLyPhimController : ControllerBase
    {
        private readonly IQuanLyPhimsRepository repository;
        public QuanLyPhimController(IQuanLyPhimsRepository repository){
            this.repository = repository;
        }

        [HttpGet("LayDanhSachPhim")]
        public IEnumerable<LayDanhSachPhimDto> LayDanhSachPhim(string tenPhim, string maNhom = "GP01"){
            var item = repository.LayDanhSachPhim(tenPhim).Select(item => item.AsDto());
            return item;
        }

        [HttpGet("LayPhim")]
        public ActionResult<LayDanhSachPhimDto> LayPhim(int maPhim){
            var item = repository.LayPhim(maPhim);

            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpGet("LayDanhSachPhimPhanTrang")]
        public ActionResult<LayDanhSachPhimPhanTrangDto> LayDanhSachPhimPhanTrang(string tenPhim, string maNhom = "GP01", int soTrang =1, int soPhanTuTrenTrang = 1){
            var item = repository.LayDanhSachPhimPhanTrang(tenPhim, maNhom, soTrang, soPhanTuTrenTrang);
            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost("ThemPhim")]
        public ActionResult<ThemPhimDto> ThemPhim(ThemPhimDto themPhimDto){
            PhimInsert insert = new(){
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

            repository.ThemPhIM(insert);
            return CreatedAtAction(nameof(LayDanhSachPhim),
                new { maPhim = themPhimDto.maPhim,
                        tenPhim = themPhimDto.tenPhim,
                        biDanh = themPhimDto.biDanh,
                        trailer = themPhimDto.trailer,
                        hinhAnh = themPhimDto.hinhAnh,
                        moTa = themPhimDto.maNhom,
                        maNhom = themPhimDto.maNhom,
                        ngayKhoiChieu =themPhimDto.ngayKhoiChieu,
                        danhGia = themPhimDto.danhGia
                    },
                insert.AsDto());
        }

         [HttpPut("CapNhatPhim")]
        public ActionResult CapNhatPhim(PhimInsert phim){
            var existingPhim = repository.LayPhim(phim.maPhim);

            if(existingPhim is null){
                return NotFound();
            }
            
            PhimInsert updatedPhim = existingPhim with {
                        tenPhim = phim.tenPhim,
                        biDanh = phim.biDanh,
                        trailer = phim.trailer,
                        hinhAnh = phim.hinhAnh,
                        moTa = phim.maNhom,
                        maNhom = phim.maNhom,
                        ngayKhoiChieu =phim.ngayKhoiChieu,
                        danhGia = phim.danhGia
            };

            repository.CapNhatPhim(updatedPhim);

            return NoContent();
        }

        [HttpDelete("XoaPhim")]
        public ActionResult XoaPhim(int maPhim){
            var existingPhim = repository.LayPhim(maPhim);

            if(existingPhim is null){
                return NotFound();
            }
            
            repository.XoaPhim(maPhim);

            return NoContent();
        }
    

    }
}