using Microsoft.EntityFrameworkCore;
using shopApplication.DAL.Entities;
using shopApplication.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopApplication.DAL.Repositories
{
    public class RepositoryAdvertisement: Repository<Advertisement>, IAdvertisementRepository
    {
        public RepositoryAdvertisement(ApplicationDbContext context) : base(context)
        {
            entities = context.Advertisements;
        }

        public Advertisement GetAllAdvertisement(int Id)
        {   
            return entities.Where(i => i.Id == Id).Include(i => i.User).Include(i => i.Images).Include(i => i.Comments).First();
        }
    }
}
