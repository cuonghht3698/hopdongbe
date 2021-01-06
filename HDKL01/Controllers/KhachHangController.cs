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
    [Route("api/khachhang")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly QLHOPDONGContext _context;
        public KhachHangController(QLHOPDONGContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult getBySdt()
        {
            var data = _context.Khachhangs.ToList();
            return Ok(data);
        }

        [HttpGet]
        [Route("getBySdt")]
        public ActionResult getBySdt(string DienThoai)
        {
            var data = _context.Khachhangs.Where(x =>x.DienThoai == DienThoai).ToList();
            return Ok(data);
        }
        [HttpPost]
        [Route("checkdoitac")]
        public ActionResult getBySdt(Khachhang model)
        {
            var check = _context.Khachhangs.Where(x => x.MaKh == model.MaKh).Where(x => x.BenA == model.BenA).Where(x => x.DaiDien == model.DaiDien).Where(x => x.ChucVu == model.ChucVu).
               Where(x => x.DiaChi == model.DiaChi).Where(x => x.DienThoai == model.DienThoai).Where(x => x.Mst == model.Mst).ToList();
            if (check.Count > 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpPost]
        public ActionResult CreateKH(Khachhang model)
        {
            var check = _context.Khachhangs.Where(x => x.BenA == model.BenA).Where(x =>x.DaiDien == model.DaiDien).Where(x =>x.ChucVu == model.ChucVu).
                Where(x => x.DiaChi == model.DiaChi).Where(x =>x.DienThoai == model.DienThoai).Where(x => x.Mst == model.Mst).Where(x => x.GioiTinh == model.GioiTinh).ToList();
            if(check.Count > 0)
            {
                return BadRequest();
            }
            model.Id = Guid.NewGuid();
            _context.Khachhangs.Add(model);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var hm = _context.Khachhangs.Find(id);
            _context.Remove(hm);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public ActionResult Update(Khachhang model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
