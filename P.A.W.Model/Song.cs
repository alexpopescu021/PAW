
using System;

namespace PAW.Model
{
    public class Song : DataEntity
    {
        
        public string Title { get; protected set; }
        public string Path { get; protected set; }
        public string Artist { get; protected set; }
        public string Genre { get; protected set; }

        protected Song()
        { 
            
        }

    }
}
