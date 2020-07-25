using shopApplication.DAL.Entities;
using shopApplication.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Repositories
{
    public class RepositoryComment: Repository<Comment>, ICommentRepository
    {
        public RepositoryComment(ApplicationDbContext context) : base(context)
        {
            entities = context.Comments;
        }
    }
}
