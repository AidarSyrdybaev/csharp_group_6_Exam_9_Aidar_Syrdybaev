using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication.Models.AdvertisementModels
{
    public class ListAdvertisementIndexModel
    {
        public List<AdvertisementIndexModel> advertisementIndexModels;

        public bool IsUser { get; set; }

        public string SearchKey { get; set; }

        public int? MaxPrice { get; set; }

        public int? MinPrice { get; set; }
        
        public int? CategoryId { get; set; }
    }
}
