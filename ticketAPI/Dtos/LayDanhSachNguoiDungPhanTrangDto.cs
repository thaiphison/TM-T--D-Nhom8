using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Dtos
{
    public record LayDanhSachNguoiDungPhanTrangDto
    {
        public int currentPage { get; set; }
        public int count { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
        public List<NguoiDungVM> items { get; set; } = new List<NguoiDungVM>();
    }
}