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

    }
}
