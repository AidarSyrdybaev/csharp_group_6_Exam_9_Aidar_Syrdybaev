using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopApplication.Models;
using shopApplication.Models.AdvertisementModels;
using shopApplication.Services.AdvertisementServices;
using shopApplication.Services.Contracts;

namespace shopApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdvertisementService _advertisementService;
        public HomeController(ILogger<HomeController> logger, IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int Id, string SearchKey, int?MaxPrice, int? MinPrice, int? CategoryId)
        {
            ViewBag.Categories = _advertisementService.GetSelectListItems();
            
            var IndexModels = await _advertisementService.GetAdvertisementIndexModels(IndexCheck.SelectAll, User);
               
            return View(IndexModels.BySearchKey(SearchKey).ByCategory(CategoryId).ByPrice(MaxPrice, MinPrice));
           

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
