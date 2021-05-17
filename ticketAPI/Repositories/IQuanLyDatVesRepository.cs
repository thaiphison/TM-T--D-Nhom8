using System.Collections.Generic;
using ticketAPI.Entities;

namespace ticketAPI.Repositories
{
    public interface IQuanLyDatVesRepository
    {
        DanhSachVeDat LayDanhSachPhongVe(int maLichChieu);
        void DatVe(DanhSachVeDat dsVeDat);

        void TaoLichChieu(LichChieuInsert lichChieuInsert);
    }
}