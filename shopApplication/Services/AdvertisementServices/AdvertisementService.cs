using shopApplication.DAL;
using shopApplication.Models.AdvertisementModels;
using shopApplication.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using shopApplication.DAL.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace shopApplication.Services.AdvertisementServices
{
    public class AdvertisementService: IAdvertisementService
    {
        UserManager<User> _userManager;
        IFileSaver _fileSaver { get; }
        IUnitOfWorkFactory _unitOfWorkFactory { get; }

        public AdvertisementService(IFileSaver fileSaver, IUnitOfWorkFactory unitOfWorkFactory, UserManager<User> userManager)
        {
            _fileSaver = fileSaver;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userManager = userManager;
        }

        public AdvertisementCreateModel GetAdvertisementCreateModel()
        {
            return new AdvertisementCreateModel();
        }

        public void Create(AdvertisementCreateModel model, int UserId)
        { 
            using(var uow = _unitOfWorkFactory.Create())
            {   
                var advertisement = Mapper.Map<Advertisement>(model);
                advertisement.UserId = UserId;
                advertisement.DateSort = DateTime.Now;
                var SaveAdvertisement = uow.Advertisements.Create(advertisement);
                var Images = _fileSaver.SaveAdvertisementImages(SaveAdvertisement, model.Images);
                var MainImageByte = _fileSaver.GetImageBytes(model.MainImage);
                var MainImage = new Image { AdvertisementId = SaveAdvertisement.Id, MainImage = true, Content = MainImageByte };
                foreach(var image in Images)
                {
                    uow.Images.Create(image);
                }
                uow.Images.Create(MainImage);
            }
        }

        public async Task<IEnumerable<AdvertisementIndexModel>> GetAdvertisementIndexModels(IndexCheck Check, ClaimsPrincipal User)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {

                var CheckModel = new AdvertisementIndexModel();
                CheckModel.IsGraphic = true;
                CheckModel.IsUser = false;
                var Models = new List<AdvertisementIndexModel>();
                var Advertisements = uow.Advertisements.GetAll().ToList();
                if (Check == IndexCheck.SelectInUserIdIndex && User.Identity.IsAuthenticated)
                {
                    CheckModel.IsUser = true;
                    var _User = await _userManager.GetUserAsync(User);
                    Advertisements = Advertisements.Where(i => i.UserId == _User.Id).ToList();
                }
                
                foreach(var advertisement in Advertisements)
                {
                    var Model = Mapper.Map<AdvertisementIndexModel>(advertisement);
                    
                    Model.MainImage = uow.Images.GetAll().FirstOrDefault(i => i.MainImage && i.AdvertisementId == advertisement.Id)?.Content;

                    Models.Add(Model);
                   
                };
                return Models.OrderByDescending(u => u.DateSort);
            }
        }

        public SelectList GetSelectListItems()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {

                var Select = new SelectList(uow.Categories.GetAll().ToList(), "Id", "Name");
                return Select;
            }
        }

        public AdvertisementDetailsModel GetAdvertisementDetailsModel(int Id)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var Entity = uow.Advertisements.GetAllAdvertisement(Id);
                var Model = Mapper.Map<AdvertisementDetailsModel>(Entity);
                return Model;
            }
        }

        public async Task AddComment(int Id, string Text, ClaimsPrincipal User)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var user = await _userManager.GetUserAsync(User);
                var comment = new Comment { AdvertisementId = Id, Text = Text, UserLogin = user.Email };
                uow.Comments.Create(comment);
            }
        }

        public void Refresh(int Id)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var Entity = uow.Advertisements.GetById(Id);
                Entity.DateSort = DateTime.Now;
                uow.Advertisements.Update(Entity);
            }
        }

        public int DeleteImage(int Id)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {   
                var Entity = uow.Images.GetById(Id);
                if (Entity.MainImage && uow.Images.GetAll().ToList().Where(i => i.AdvertisementId == Entity.AdvertisementId).Count() > 1)
                {
                    var Entites = uow.Images.GetAll().ToList().Where(i => i.AdvertisementId == Entity.AdvertisementId).FirstOrDefault(i => i.Id != Id);
                    Entites.MainImage = true;
                    uow.Images.Update(Entites);
                }
                int AdvertisementId = Entity.AdvertisementId;
                uow.Images.Remove(Entity);
                return AdvertisementId;
                
            }
        }

        public void Edit(AdvertisementEditModel Model)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var advertisement = Mapper.Map<Advertisement>(Model);
                if (Model.Images != null)
                {
                    var Images = _fileSaver.SaveAdvertisementImages(advertisement, Model.FormImages);
                    foreach (var image in Images)
                    {
                        uow.Images.Create(image);
                    }
                }
               
                if (Model.FormMainImage != null)
                {
                    var advertisement2 = uow.Advertisements.GetAllImagesAdvertisement(advertisement.Id);
                    var MainImageByte = _fileSaver.GetImageBytes(Model.FormMainImage);
                    var MainImage = new Image { AdvertisementId = advertisement.Id, MainImage = true, Content = MainImageByte };
                    

                    if (advertisement2.Images.ToList().Where(i => i.MainImage) != null)
                    {
                        var Main = advertisement2.Images.FirstOrDefault(i => i.MainImage);
                        Main.MainImage = false;
                        uow.Images.Update(Main);
                    }

                    uow.Images.Create(MainImage);

                }
               

                uow.Advertisements.Update(advertisement);
                
            }
        }

        public AdvertisementEditModel GetAdvertisementEditModel(int Id)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var Entity = uow.Advertisements.GetAllImagesAdvertisement(Id);
                return Mapper.Map<AdvertisementEditModel>(Entity);

            }
        }
    }
}
