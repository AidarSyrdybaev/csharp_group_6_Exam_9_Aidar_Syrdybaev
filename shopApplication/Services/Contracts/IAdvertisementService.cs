using shopApplication.Models.AdvertisementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopApplication.Services.AdvertisementServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace shopApplication.Services.Contracts
{
    public interface IAdvertisementService
    {
        AdvertisementCreateModel GetAdvertisementCreateModel();

        void Create(AdvertisementCreateModel model, int UserId);

        Task<IEnumerable<AdvertisementIndexModel>> GetAdvertisementIndexModels(IndexCheck Check, ClaimsPrincipal User);

        SelectList GetSelectListItems();

        AdvertisementDetailsModel GetAdvertisementDetailsModel(int Id);

        Task AddComment(int Id, string Text, ClaimsPrincipal User);

        void Refresh(int Id);

        int DeleteImage(int Id);

        AdvertisementEditModel GetAdvertisementEditModel(int Id);

        void Edit(AdvertisementEditModel advertisementEditModel);
    }
}
