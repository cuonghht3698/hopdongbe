using System;
using System.Collections.Generic;

#nullable disable

namespace HDKL01.Models
{
    public partial class Sanpham
    {
        public Guid Id { get; set; }
        public string HangMuc { get; set; }
        public string Dvt { get; set; }
        public decimal? DonGia { get; set; }
    }
}
