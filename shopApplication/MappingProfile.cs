using AutoMapper;
using shopApplication.DAL.Entities;
using shopApplication.Models.AdvertisementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopApplication
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            AdvertisementMapping();
        }

        private void AdvertisementMapping()
        {
            CreateMap<AdvertisementCreateModel, Advertisement>().ForMember(i => i.Images, src => src.Ignore());
            CreateMap<Advertisement, AdvertisementIndexModel>();
            CreateMap<Advertisement, AdvertisementDetailsModel>();
            CreateMap<AdvertisementEditModel, Advertisement>();
            CreateMap<Advertisement, AdvertisementEditModel>();
        }
    }
}
