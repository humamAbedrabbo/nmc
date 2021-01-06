using Microsoft.AspNetCore.Hosting;
using NetBarcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Services
{
    public class BarcodeGen : IBarcodeGen
    {
        private readonly IWebHostEnvironment env;

        public BarcodeGen(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void Generate(int idInpatient)
        {
            var path = Path.Combine(env.WebRootPath, "barcode");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, $"{idInpatient}.jpeg");
                var barcode = new Barcode($"{idInpatient}", true);
                barcode.SaveImageFile(path: path);
            
        }
    }
}
