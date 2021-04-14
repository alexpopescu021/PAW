
using System;

namespace PAW.Model
{
    public class Song : DataEntity
    {
        
        public string Title { get; protected set; }
        public string Path { get; protected set; }
        public string Artist { get; protected set; }
        public string Genre { get; protected set; }

        public static Song Create(string artist, string genre, string path, string title)
        {

            return new Song
            {
                Id = Guid.NewGuid(),
                Artist = artist,
                Genre = genre,
                Path = path,
                Title = title
            };
        }

        public Song Update(string artist, string genre, string title)
        {
            this.Title = title;
            this.Artist = artist;
            this.Genre = genre;

            return this;
        }

    }
}
