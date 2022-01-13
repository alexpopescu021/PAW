using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class History : DataEntity
    {
        public virtual List<Song> Songs { get; set; }
        public decimal total { get; set; }

        public static History Create()
        {
            return new History { Id = Guid.NewGuid() };
        }
    }
}
