using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class Quiz : DataEntity
    {
        public Song Song { get; protected set; }

        public string Answer1 { get; protected set; }
        public string Answer2 { get; protected set; }
        
        public string RightAnswer { get; protected set; }


        public static Quiz Create(Song song, string answer1, string answer2, string right_answer)
        {

            return new Quiz
            {
                Id = Guid.NewGuid(),
                Song = song,
                Answer1 = answer1,
                Answer2 = answer2,
                RightAnswer = right_answer
            };
        }

    }
}
