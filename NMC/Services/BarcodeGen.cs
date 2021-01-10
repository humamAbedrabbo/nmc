using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using NetBarcode;
using NMC.Data;
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
        private readonly NmcContext context;

        public BarcodeGen(IWebHostEnvironment env, NmcContext context)
        {
            this.env = env;
            this.context = context;
        }

        public string Generate(int idInpatient, string room = "")
        {
            //return;

            var path = Path.Combine(env.WebRootPath, "barcode");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, $"{idInpatient}.jpeg");
            string roomStr = string.IsNullOrEmpty(room) ? "" : $" {room}";
            
            var barcode = new Barcode($"{idInpatient}{roomStr}", true);
            //barcode.SaveImageFile(path: path);
            return barcode.GetBase64Image();
            
        }
    }
}
