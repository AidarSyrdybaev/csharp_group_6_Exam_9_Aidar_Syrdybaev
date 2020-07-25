using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shopApplication.DAL.Entities;
using shopApplication.Models.AdvertisementModels;
using shopApplication.Services.AdvertisementServices;
using shopApplication.Services.Contracts;

namespace shopApplication.Controllers
{
    public class AdvertisementController : Controller
    {
        IAdvertisementService _advertisementService;

        UserManager<User> _UserManager;
        public AdvertisementController(IAdvertisementService advertisementService, UserManager<User> usermanager)
        {
            _advertisementService = advertisementService;
            _UserManager = usermanager;
        }


        [Authorize]
        public async Task<IActionResult> Index(int Id, string SearchKey, int? MaxPrice, int? MinPrice, int? CategoryId)
        {
            ViewBag.Categories = _advertisementService.GetSelectListItems();
            var IndexModels = await _advertisementService.GetAdvertisementIndexModels(IndexCheck.SelectInUserIdIndex, User);
            IndexModels = IndexModels.BySearchKey(SearchKey).ByCategory(CategoryId).ByPrice(MaxPrice, MinPrice);
            return View(IndexModels);

        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = _advertisementService.GetSelectListItems();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AdvertisementCreateModel model)
        {
            var _User = await _UserManager.GetUserAsync(User);
            _advertisementService.Create(model, _User.Id);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details(int Id)
        {
            return View(_advertisementService.GetAdvertisementDetailsModel(Id));
        }

        public async Task<IActionResult> AddComment(int Id, string Text)
        {
            await _advertisementService.AddComment(Id, Text, User);
            return RedirectToAction("Details", new { Id});
        }

        public async Task<IActionResult> RefreshAdvertisement(int Id)
        {
            _advertisementService.Refresh(Id);
            return RedirectToAction("Details", new { Id });
        }

        public async Task<IActionResult> DeleteImage(int Id)
        {
            int AdvertisementId = _advertisementService.DeleteImage(Id);
            return RedirectToAction("Edit", new { Id = Id});
        }

        public async Task<IActionResult> Edit(int Id)
        {
            
            return View(_advertisementService.GetAdvertisementEditModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AdvertisementEditModel model)
        {
            _advertisementService.Edit(model);
            return RedirectToAction("Details",new {Id = model.Id });
        }

    }
}
