using ticketAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ticketAPI.Repositories
{
    public class InMemQuanLyDatVesRepository : IQuanLyDatVesRepository
    {
        private readonly List<DanhSachVeDat> danhSachVeDats = new(){
            new DanhSachVeDat { 
                maLichChieu = 1, 
                danhSachVe = new() {
                    new VeVM { maGhe = 2, giaVe = 50000 },
                    new VeVM { maGhe = 3, giaVe = 50000 },
                    new VeVM { maGhe = 4, giaVe = 50000 }
                },
                taiKhoanNguoiDung = "nguoidungA"
            },

            new DanhSachVeDat { 
                maLichChieu = 2, 
                danhSachVe = new List<VeVM>() {
                    new VeVM { maGhe = 1, giaVe = 50000 },
                    new VeVM { maGhe = 2, giaVe = 50000 },
                    new VeVM { maGhe = 3, giaVe = 50000 }
                },
                taiKhoanNguoiDung = "nguoidungB"
            }
        };

        private readonly List<LichChieuInsert> danhSachLichChieus = new(){
            new LichChieuInsert { maPhim = 1, ngayChieuGioChieu = "05/05/2021", maRap = 1, giaVe = 50000},
            new LichChieuInsert { maPhim = 2, ngayChieuGioChieu = "05/05/2021", maRap = 1, giaVe = 50000}
        };

        public DanhSachVeDat LayDanhSachPhongVe(int maLichChieu)
        {
            return danhSachVeDats.Where(item => item.maLichChieu == maLichChieu).SingleOrDefault();
        }

        public void DatVe(DanhSachVeDat veDat)
        {
            danhSachVeDats.Add(veDat);
        }

        public void TaoLichChieu(LichChieuInsert lichChieuInsert){
            danhSachLichChieus.Add(lichChieuInsert);
        }
    }
}