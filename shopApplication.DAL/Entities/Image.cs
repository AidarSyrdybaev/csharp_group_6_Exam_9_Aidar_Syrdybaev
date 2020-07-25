using System;
using System.Collections.Generic;
using System.Text;

namespace shopApplication.DAL.Entities
{
    public class Image: IEntity
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public int AdvertisementId { get; set; }

        public bool MainImage { get; set; }

        public Advertisement Advertisement { get; set; }
    }
}
