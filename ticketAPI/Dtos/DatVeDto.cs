using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Dtos
{
    public record DatVeDto
    {
        public int maLichChieu { get; set; }
        public  List<VeVM> danhSachVe { get; set; } = new List<VeVM>();
        public string taiKhoanNguoiDung { get; set; }
    }
}