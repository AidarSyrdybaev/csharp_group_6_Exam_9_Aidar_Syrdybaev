﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Entities
{
    public class Category: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
