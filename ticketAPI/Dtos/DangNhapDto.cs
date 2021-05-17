namespace ticketAPI.Dtos
{
    public record DangNhapDto
    {
        public string taiKhoan { get; set; }
        public string email { get; set; }
        public string soDt { get; set; }
        public string maNhom { get; set; }
        public string maLoaiNguoiDung { get; set; }
        public string hoTen { get; set; }
         public string accessToken { get; set; }
    }
}