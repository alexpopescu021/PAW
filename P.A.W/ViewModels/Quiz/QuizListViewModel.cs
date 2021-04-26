using PAW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAW.ViewModels.Quizes
{
    public class QuizListViewModel
    {
        public IEnumerable<Quiz> QuizViews { get; set; }
    }
}
