using Microsoft.AspNetCore.Http;
using shopApplication.DAL.Entities;
using shopApplication.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Services.FileService
{
    public class FileSaver: IFileSaver
    {
        public IEnumerable<Image> SaveAdvertisementImages(Advertisement advertisement, IFormFileCollection images)
        { 
            foreach(var image in images)
            {
                yield return new Image { Content = GetImageBytes(image), AdvertisementId = advertisement.Id };
            }
        }
        public byte[] GetImageBytes(IFormFile formFile)
        {
            using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
            {
                return binaryReader.ReadBytes((int)formFile.Length);
            }
        }
    }
}
