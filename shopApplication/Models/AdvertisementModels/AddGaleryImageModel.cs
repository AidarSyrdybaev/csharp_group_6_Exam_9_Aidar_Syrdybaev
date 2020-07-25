using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Models.AdvertisementModels
{
    public class AddGaleryImageModel
    {
        [Required]
        public int AdvertisementId { get; set; }

        public IFormFileCollection Images { get; set; }
    }
}
