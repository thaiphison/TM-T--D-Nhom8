using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Dtos
{
    public class LayDanhSachPhimPhanTrangDto
    {
        public int currentPage { get; set; }
        public int count { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
        public List<PhimInsert> items { get; set; } = new List<PhimInsert>();
    }
}