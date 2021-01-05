using System;
using System.Collections.Generic;

#nullable disable

namespace HDKL01.Models
{
    public partial class ChiTietLichSu
    {
        public Guid Id { get; set; }
        public string HangMuc { get; set; }
        public string Dvt { get; set; }
        public decimal? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
        public Guid? LichSuId { get; set; }

        public virtual LichSu LichSu { get; set; }
    }
}
