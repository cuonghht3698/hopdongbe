using HDKL01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDKL01.DTO
{
    public class LichSuDTO
    {
        public Guid Id { get; set; }
        public bool? GioiTinh { get; set; }
        public string BenA { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Mst { get; set; }
        public string DaiDien { get; set; }
        public string ChucVu { get; set; }
        public string DiaDienTrinhDien { get; set; }
        public DateTime? ThoiGianThucHien { get; set; }
        public string ThoiGianLapDat { get; set; }
        public decimal? Tong { get; set; }
        public decimal? Vat { get; set; }
        public decimal? GiaTriHopDong { get; set; }
        public DateTime? NgayTao { get; set; }

        public List<ChiTietLichSu> Chitiet { get; set; }
    }
}
