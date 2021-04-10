using System;
using System.Collections.Generic;
using System.Text;

namespace PAWDataAcess.Abstractions
{
    public interface IPersistanceContext
    {
        ISongRepository SongRepository { get; }
        void SaveChanges();
    }
}
