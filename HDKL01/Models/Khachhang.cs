using System;
using System.Collections.Generic;

#nullable disable

namespace HDKL01.Models
{
    public partial class Khachhang
    {
        public Guid Id { get; set; }
        public bool? GioiTinh { get; set; }
        public string BenA { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Mst { get; set; }
        public string DaiDien { get; set; }
        public string ChucVu { get; set; }
    }
}
