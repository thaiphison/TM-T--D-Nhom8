using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Dtos
{
    public record LoaiNguoiDungDto
    {
        public string maLoaiNguoiDung { get; set; }
        public string tenLoai { get; set; }
    }
}