using System.Collections.Generic;
namespace ticketAPI.Entities
{
    public record LoaiNguoiDung
    {
        public string maLoaiNguoiDung { get; set; }
        public string tenLoai { get; set; }
    }
}