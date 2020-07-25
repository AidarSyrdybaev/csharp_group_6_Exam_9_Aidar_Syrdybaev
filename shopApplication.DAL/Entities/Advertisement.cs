using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Entities
{
    public class Advertisement: IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }

        public ICollection<Image> Images { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime DateSort { get; set; }

    }
}
