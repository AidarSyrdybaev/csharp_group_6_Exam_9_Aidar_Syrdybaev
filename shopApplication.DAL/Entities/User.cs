using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
