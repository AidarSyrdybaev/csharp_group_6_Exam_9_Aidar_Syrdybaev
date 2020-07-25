using Microsoft.AspNetCore.Http;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Models.AdvertisementModels
{
    public class AdvertisementIndexModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "заголовок")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "контактный номер")]
        public string ContactNumber { get; set; }
        [Required]
        [Display(Name = "заглавная картинка")]
        public byte[] MainImage { get; set; }

        public int CategoryId { get; set; }

        public bool IsUser { get; set; }

        public bool IsGraphic { get; set; }

        public DateTime DateSort { get; set; }
    }
}
