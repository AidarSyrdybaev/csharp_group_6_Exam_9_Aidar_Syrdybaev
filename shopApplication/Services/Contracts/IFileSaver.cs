using Microsoft.AspNetCore.Http;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Services.Contracts
{
    public interface IFileSaver
    {
        byte[] GetImageBytes(IFormFile formFile);

        IEnumerable<Image> SaveAdvertisementImages(Advertisement advertisement, IFormFileCollection images);
    }
}
