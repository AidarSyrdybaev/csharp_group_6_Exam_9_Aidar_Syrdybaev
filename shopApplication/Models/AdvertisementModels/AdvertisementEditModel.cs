using Microsoft.AspNetCore.Http;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Models.AdvertisementModels
{
    public class AdvertisementEditModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }

        public IFormFileCollection FormImages { get; set; }

        public ICollection<Image> Images { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IFormFile FormMainImage { get; set; }

        public DateTime DateSort { get; set; }
    }
}
