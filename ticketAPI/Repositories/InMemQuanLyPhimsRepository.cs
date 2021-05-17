using ticketAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ticketAPI.Dtos;

namespace ticketAPI.Repositories
{
    public class InMemQuanLyPhimsRepository : IQuanLyPhimsRepository
    {
        private readonly List<PhimInsert> danhSachPhim = new(){
            new PhimInsert { 
                maPhim =  1464,
                tenPhim = "The Longest Ride",
                biDanh = "the-longest-ride",
                trailer = "https://www.youtube.com/embed/FUS_Q7FsfqU",
                hinhAnh = "http://movie0706.cybersoft.edu.vn/hinhanh/thelongestride.jpg",
                moTa = "After an automobile crash, the lives of a young couple intertwine with a much older man, as he reflects back on a past love.",
                maNhom = "GP01",
                ngayKhoiChieu = "2019-07-29T00:00:00",
                danhGia = 5
            },
            new PhimInsert { 
                maPhim =  1509,
                tenPhim = "Specter",
                biDanh = "specter",
                trailer = "https://www.youtube.com/embed/LTDaET-JweU",
                hinhAnh = "http://movie0706.cybersoft.edu.vn/hinhanh/spectre.jpg",
                moTa = "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.",
                maNhom = "GP01",
                ngayKhoiChieu = "2021-04-22T00:00:00",
                danhGia = 10
            },
            new PhimInsert { 
                maPhim =  2864,
                tenPhim = "Transformers",
                biDanh = "transformers",
                trailer = "https://www.youtube.com/watch?v=AntcyqJ6brc",
                hinhAnh = "http://movie0706.cybersoft.edu.vn/hinhanh/transformers_gp01.png",
                moTa = "Cách đây chừng 4 triệu năm, trên hành tinh Cybertron xa xôi tồn tại một nền văn minh của robot. nhưng rồi nền văn minh ấy bị tàn phá bởi cuộc chiến kéo dài nhiều thế kỷ giữa hai chủng người máy: autobot (phe thiện) và deception (phe ác). Chúng đánh nhau để tranh giành allspark (thực thể lập phương) – thứ có khả năng mang tới quyền lực tối thượng cho kẻ sở hữu nó.",
                maNhom = "GP01",
                ngayKhoiChieu = "2020-04-20T00:00:00",
                danhGia = 8
            },
            new PhimInsert { 
                maPhim =  4428,
                tenPhim = "Sky Toura",
                biDanh = "sky-toura",
                trailer = "https://www.youtube.com/embed/t7m1iqs_b-U",
                hinhAnh = "http://movie0706.cybersoft.edu.vn/hinhanh/sky-toura_gp01.jpg",
                moTa = "Lần đầu tiên tại Việt Naam, một nghệ sĩ phát hành bộ phim tài liệu âm nhạc về tour diễn của mình trên màn ảnh rộng. Bộ phim hứa hẹn sẽ đem đến cho khán giả những khoảnh khắc đẹp đẽ nhất về sự kiện âm nhạc đình đám nhất năm 2019, khi Sơn Tùng M-TP hết mình cùng hàng nghìn người hâm mộ trong âm nhạc và cả những cảnh hậu trường ghi lại toàn bộ quá trình chuẩn bị và sản xuất SKY TOUR.",
                maNhom = "GP01",
                ngayKhoiChieu = "2020-06-12T00:00:00",
                danhGia = 8
            },
        };

        public void CapNhatPhim(PhimInsert nd)
        {
            var index = danhSachPhim.FindIndex(existingPhim => existingPhim.maPhim == nd.maPhim);
            
            danhSachPhim[index] = nd;
        }

        public List<PhimInsert> LayDanhSachPhim(string tenPhim, string maNhom = "GP01")
        {
            List<PhimInsert> dsPhim = new List<PhimInsert>();
            foreach ( PhimInsert phim in danhSachPhim){
                if(phim.tenPhim.ToString().Contains(tenPhim) && phim.maNhom.ToString()=="GP01"){
                    dsPhim.Add(phim);
                }
            }
            return dsPhim;
        }

        public LayDanhSachPhimPhanTrangDto LayDanhSachPhimPhanTrang(string tenPhim, string maNhom = "GP01", int soTrang = 1, int soPhanTuTrenTrang = 1)
        {
            LayDanhSachPhimPhanTrangDto danhSachPhimPhanTrang = new LayDanhSachPhimPhanTrangDto();
            foreach ( PhimInsert phim in danhSachPhim){
                if(phim.tenPhim.ToString().Contains(tenPhim) && phim.maNhom.ToString()=="GP01"){
                    danhSachPhimPhanTrang.items.Add(phim);
                }
            }
            return danhSachPhimPhanTrang;
        }

        public PhimInsert LayPhim(int maPhim)
        {
            return danhSachPhim.Where(item => item.maPhim == maPhim).SingleOrDefault();
        }

        public void ThemPhIM(PhimInsert nd)
        {
            danhSachPhim.Add(nd);
        }

        public void XoaPhim(int maPhim)
        {
            var index = danhSachPhim.FindIndex(existingPhim => existingPhim.maPhim == maPhim);
            danhSachPhim.RemoveAt(index);
        }
    }
}