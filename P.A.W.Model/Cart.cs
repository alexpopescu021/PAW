using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class Cart : DataEntity
    {
        public virtual List<Song> Songs { get; set; }
        public decimal total { get; set; }

        public static Cart Create()
        {
            return new Cart { Id = Guid.NewGuid() };
        }
    }
}
