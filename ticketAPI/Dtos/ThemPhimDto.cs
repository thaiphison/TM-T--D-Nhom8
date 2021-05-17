namespace ticketAPI.Dtos
{
    public record ThemPhimDto
    {
        public int maPhim { get; set; }
        public string tenPhim { get; set; }
        public string biDanh { get; set; }
        public string trailer { get; set; }
        public string hinhAnh { get; set; }
        public string moTa { get; set; }
        public string maNhom { get; set; }
        public string ngayKhoiChieu { get; set; }
        public int danhGia { get; set; }
    }
}