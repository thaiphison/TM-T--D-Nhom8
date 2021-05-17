namespace ticketAPI.Entities
{
    public record LichChieuInsert
    {
        public int maPhim { get; set; }
        public string ngayChieuGioChieu { get; set; }
        public int maRap { get; set; }
        public double giaVe { get; set; }
    }
}