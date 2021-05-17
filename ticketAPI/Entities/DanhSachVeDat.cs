using System.Collections.Generic;

namespace ticketAPI.Entities
{
    public record DanhSachVeDat
    {
        public int maLichChieu { get; set; }
        public  List<VeVM> danhSachVe { get; set; } = new List<VeVM>();
        public string taiKhoanNguoiDung { get; set; }
    }
}