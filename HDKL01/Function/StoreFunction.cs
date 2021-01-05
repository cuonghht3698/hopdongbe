using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HDKL01.Function
{
    public static class StoreFunction
    {
        public static string GetBaseURl()
        {
            string url = Directory.GetCurrentDirectory();
            return url;
        }
        public static bool SingleFile(IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(StoreFunction.GetBaseURl() + "\\Upload", file.FileName), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            return true;
        }

    }
}
