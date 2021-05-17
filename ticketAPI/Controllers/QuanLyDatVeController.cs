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
    [Route("api/QuanLyDatVe")]
    public class QuanLyDatVeController : ControllerBase
    {
        private readonly IQuanLyDatVesRepository repository;

        public QuanLyDatVeController(IQuanLyDatVesRepository repository){
            this.repository = repository;
        }

        [HttpGet("LayDanhSachPhongVe")]
        public ActionResult<DatVeDto> LayDanhSachPhongVe(int maLichChieu){
            var item = repository.LayDanhSachPhongVe(maLichChieu);

            if(item is null){
                return NotFound();
            }

            return item.AsDto();
        }

        //Post /api/QuanLyDatVe/DatVe
        [HttpPost("DatVe")]
        public ActionResult<DatVeDto> DatVe(DatVeDto datVeDto){
            DanhSachVeDat datVe = new(){
                maLichChieu = datVeDto.maLichChieu,
                danhSachVe = datVeDto.danhSachVe,
                taiKhoanNguoiDung = datVeDto.taiKhoanNguoiDung
            };

            repository.DatVe(datVe);
            return CreatedAtAction(nameof(LayDanhSachPhongVe),
                new { maLichChieu = datVe.maLichChieu },
                datVe.AsDto());
        }

        //Post /api/QuanLyDatVe/TaoLichChieu
        [HttpPost("TaoLichChieu")]
        public ActionResult<LichChieuInsertDto> TaoLichChieu(LichChieuInsertDto lichChieuInsertDto){
            LichChieuInsert lichChieuInsert = new(){
                maPhim = lichChieuInsertDto.maPhim,
                ngayChieuGioChieu = lichChieuInsertDto.ngayChieuGioChieu,
                maRap = lichChieuInsertDto.maRap,
                giaVe = lichChieuInsertDto.giaVe
            };

            repository.TaoLichChieu(lichChieuInsert);
            return CreatedAtAction(nameof(TaoLichChieu),
                new {
                    maPhim = lichChieuInsert.maPhim,
                    maRap = lichChieuInsert.maRap
                },
                lichChieuInsert.AsDto());
        }
    }
}