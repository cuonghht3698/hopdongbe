using HDKL01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HDKL01.Function;
namespace HDKL01.Controllers
{
    [Route("image")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly QLHopDongContext _context;

        public ImagesController(QLHopDongContext context)
        {
            _context = context;
        }

        [HttpGet("{img}")]
        public IActionResult GetFile(string img)
        {
            string url = Directory.GetCurrentDirectory();
            var imageFileStream = System.IO.File.OpenRead(url + "\\upload\\" + img);
            return File(imageFileStream, "image/jpeg");
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult getAll()
        {
            var data = _context.Dmanhs.ToList();

            return Ok(data.Select(x => new Dmanh
            {
                Id = x.Id,
                FileUrl = GetBaseURl() + "image/" + x.FileUrl
            }));
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _context.Dmanhs.AddAsync(new Dmanh { FileUrl = file.FileName });
            await _context.SaveChangesAsync();
            Function.StoreFunction.SingleFile(file);
            return Ok("ok");
        }


        public string GetBaseURl()
        {
            string location = new Uri($"{Request.Scheme}://{Request.Host}").ToString();
            return location;
        }
    }
}
