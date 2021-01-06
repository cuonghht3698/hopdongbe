using System;
using System.Collections.Generic;

#nullable disable

namespace HDKL01.Models
{
    public partial class LichSu
    {
        public LichSu()
        {
            ChiTietLichSus = new HashSet<ChiTietLichSu>();
        }

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
        public bool? TrangThai { get; set; }

        public virtual ICollection<ChiTietLichSu> ChiTietLichSus { get; set; }
    }
}
