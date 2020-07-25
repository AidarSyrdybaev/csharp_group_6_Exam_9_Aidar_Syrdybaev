using shopApplication.DAL.Entities;
using shopApplication.Models.AdvertisementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Services.AdvertisementServices
{
    public static class AdvertisementExtensions
    {
        public static IEnumerable<AdvertisementIndexModel> BySearchKey(this IEnumerable<AdvertisementIndexModel> Advertisements, string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
                Advertisements = Advertisements.Where(r => r.Title.Contains(searchKey) || r.Description.Contains(searchKey));

            return Advertisements;
        }

        public static IEnumerable<AdvertisementIndexModel> ByPrice(this IEnumerable<AdvertisementIndexModel> Advertisements, int? MaxPrice, int? MinPrice)
        {
            if (MaxPrice.HasValue)
                Advertisements = Advertisements.Where(i => i.Price < MaxPrice);
            if (MinPrice.HasValue)
                Advertisements = Advertisements.Where(i => i.Price > MaxPrice);

            return Advertisements;
        }

        public static IEnumerable<AdvertisementIndexModel> ByCategory(this IEnumerable<AdvertisementIndexModel> Advertisements, int? CategoryId)
        {
            if (CategoryId.HasValue)
                Advertisements = Advertisements.Where( i=> i.CategoryId == CategoryId);
            return Advertisements;
        }


    }
}
