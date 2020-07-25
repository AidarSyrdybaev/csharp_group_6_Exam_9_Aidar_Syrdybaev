using Microsoft.AspNetCore.Http;
using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Models.AdvertisementModels
{
    public class AdvertisementCreateModel
    {   
        public int Id { get; set; }
        [Required]
        [Display(Name ="заголовок")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Цена")]
        public int Price { get; set; }
        [Required]
        [Display(Name ="Описание")]
        public string Description { get; set; }
        [Required]
        [Display(Name ="контактный номер")]
        public string ContactNumber { get; set; }
        [Required]
        public IFormFileCollection Images { get; set; }
        [Required]
        public IFormFile MainImage { get; set; }
        [Required]
        [Display(Name ="категория товара")]
        public int CategoryId { get; set; }
    }
}
