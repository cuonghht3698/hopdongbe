using HDKL01.DTO;
using HDKL01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDKL01.Controllers
{
    [Route("api/lichsu")]
    [ApiController]
    public class LichSuController : ControllerBase
    {
        private readonly QLHopDongContext _context;
        public LichSuController(QLHopDongContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public Object getLichSu()
        {
            var ls = _context.LichSus.ToList();
            var data = from l in ls
                       join ct in _context.ChiTietLichSus on l.Id equals ct.LichSuId
                       select new { l, ct };
            return data;
        }

        [HttpPost]
        public ActionResult CreateLS(LichSuDTO model)
        {
            var dataLS = new LichSu
            {
                BenA = model.BenA,
                ChucVu = model.ChucVu,
                DaiDien = model.DaiDien,
                DiaChi = model.DiaChi,
                DiaDienTrinhDien = model.DiaDienTrinhDien,
                DienThoai = model.DienThoai,
                GiaTriHopDong = model.GiaTriHopDong,
                NgayTao = model.NgayTao,
                Tong = model.Tong,
                GioiTinh = model.GioiTinh,
                Mst = model.Mst,
                ThoiGianLapDat = model.ThoiGianLapDat,
                ThoiGianThucHien = model.ThoiGianThucHien,
                Vat = model.Vat,
                Id = Guid.NewGuid(),
 
            };
            _context.LichSus.Add(dataLS);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
