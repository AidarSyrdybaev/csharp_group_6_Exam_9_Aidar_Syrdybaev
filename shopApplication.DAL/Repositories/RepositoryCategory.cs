using shopApplication.DAL.Entities;
using shopApplication.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopApplication.DAL.Repositories
{
    public class RepositoryCategory: Repository<Category>, ICategoryRepository
    {
        public RepositoryCategory(ApplicationDbContext context) : base(context)
        {
            entities = context.Categories;
            if(!entities.ToList().Any(i => i.Name == "Продукты"))
            {
                entities.Add(new Category { Name = "Продукты" });
                context.SaveChanges();
            }
        }
    }
}
