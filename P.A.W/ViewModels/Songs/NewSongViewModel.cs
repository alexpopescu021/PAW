using Microsoft.AspNetCore.Http;
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

        [Required(ErrorMessage = "Price is required.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Picture is required.")]
        [Display(Name = "Picture")]
        public string file { get; set; }

    } 
}
