using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class Wishlist : DataEntity
    {
        public virtual List<Song> Songs { get; set; }

        public static Wishlist Create()
        {
            return new Wishlist { Id = Guid.NewGuid() };
        }
    }
}
