using PAW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.ViewModels
{
    public class SongListViewModel
    {
        public IEnumerable<Song> SongViews { get; set; }
    }
}
