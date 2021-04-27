using Microsoft.AspNetCore.Mvc.Rendering;
using PAW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.ViewModels
{
    public class NewQuizViewModel
    {

        [Required(ErrorMessage = "Song required")]
        [Display(Name = "Song")]
        public string SongId { get; set; }

        [Required(ErrorMessage = "Answer1 number required")]
        [Display(Name = "Answer1")]
        public string Answer1 { get; set; }

        [Required(ErrorMessage = "Answer2 required")]
        [Display(Name = "Answer2")]
        public string Answer2 { get; set; }

        [Required(ErrorMessage = "RightAnswer required")]
        [Display(Name = "RightAnswer")]
        public string RightAnswer { get; set; }


        public List<SelectListItem> SongList { get; set; }

    }
}
