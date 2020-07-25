using shopApplication.DAL.Entities;
using shopApplication.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Repositories
{
    public class RepositoryCategory: Repository<Category>, ICategoryRepository
    {
        public RepositoryCategory(ApplicationDbContext context) : base(context)
        {
            entities = context.Categories;
        }
    }
}
