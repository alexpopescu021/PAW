using PAW.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PAWDataAcess.Abstractions
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        IEnumerable<Song> FindByName(string nameToFind);    // more songs with the same name
        new Song GetById(Guid songId);
        new IEnumerable<Song> GetAll();
        bool RemoveSong(Guid songId);
        Song UpdateSong(Guid songId, string title, string genre, string artist);
    }
}
