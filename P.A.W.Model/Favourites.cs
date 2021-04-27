using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class Favourites : DataEntity
    {

        public string userId { get; set; }

        public List<Song> favourites { get; set; }
    }
}
