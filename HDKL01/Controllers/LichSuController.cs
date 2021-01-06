using HDKL01.DTO;
using HDKL01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly QLHOPDONGContext _context;
        public LichSuController(QLHOPDONGContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public async Task<Object> getLichSu()
        {
            var ls = await _context.LichSus.Include(x =>x.ChiTietLichSus).OrderBy(x =>x.TrangThai).ToListAsync();
            return ls;
        }

        [HttpGet("{id}")]
        public async Task<Object> getById(Guid Id)
        {
            var ls = await _context.LichSus.Where(x =>x.Id == Id).Include(x => x.ChiTietLichSus).ToListAsync();
            return ls;
        }
        [HttpPost]
        public ActionResult CreateLS(LichSuDTO model)
        {
            var IdLS = Guid.NewGuid();
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
                Id = IdLS,
                TrangThai = false,
                MaKh = model.maKH,
                SoHd = model.soHD,
                SoTk = model.soTK,
                NgayKy = model.ngayKy,
                TenCt = model.tenCT
            };
            _context.LichSus.Add(dataLS);

            foreach(ChiTietLichSu item in model.Chitiet)
            {
                item.Id = Guid.NewGuid();
                item.LichSuId = IdLS;
                _context.ChiTietLichSus.Add(item);
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
