using shopApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Repositories.Contracts
{
    public interface IAdvertisementRepository: IRepository<Advertisement>
    {
        Advertisement GetAllAdvertisement(int Id);
    }
}
