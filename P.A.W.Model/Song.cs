
using System;

namespace PAW.Model
{
    public class Song : DataEntity
    {
     

        public string Title { get;  set; }
        public string Path { get; protected set; }
        public string Artist { get;  set; }
        public string Genre { get; protected set; }

        public int NumberInCart { get;  set; }
        public decimal Price { get;  set; }

        public static Song Create(string artist, string genre, string title, decimal price, string path = null)
        {

            return new Song
            {
                Id = Guid.NewGuid(),
                Artist = artist,
                Genre = genre,
                Path = path,
                Title = title,
                Price = price
            };
        }

        public Song Update(string artist, string genre, string title, decimal price, string path)
        {
            this.Title = title;
            this.Artist = artist;
            this.Genre = genre;
            this.Price = price;
            this.Path = path;

            return this;
        }

        public Song Update(string artist, string genre, string title, decimal price)
        {
            this.Title = title;
            this.Artist = artist;
            this.Genre = genre;
            this.Price = price;

            return this;
        }

    }
}
