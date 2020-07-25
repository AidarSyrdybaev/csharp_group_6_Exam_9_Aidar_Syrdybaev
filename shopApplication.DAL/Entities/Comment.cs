using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Entities
{
    public class Comment: IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AdvertisementId { get; set; }

        public Advertisement Advertisement;

        public string UserLogin { get; set; }
    }
}
