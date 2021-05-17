using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Dtos
{
    public record LichChieuInsertDto
    {
        public int maPhim { get; set; }
        public string ngayChieuGioChieu { get; set; }
        public int maRap { get; set; }
        public double giaVe { get; set; }
    }
}