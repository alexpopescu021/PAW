using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.ViewModels.Songs
{
    public class NewSongViewModel
    {

        [Required]

        public Guid SongId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Genre is required.")]
        [Display(Name = "Genre")]
        public string Genre { get; set; }
        



        [Required(ErrorMessage = "Artist is required.")]
        [Display(Name = "Artist")]
        public string Artist { get; set; }
        
    } 
}
