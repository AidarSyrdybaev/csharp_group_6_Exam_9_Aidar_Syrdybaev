using shopApplication.DAL.Entities;
using shopApplication.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Repositories
{
    public class RepositoryImage : Repository<Image>, IImageRepository
    {
        public RepositoryImage(ApplicationDbContext context) : base(context)
        {
            entities = context.Images;
        }
    }
}
