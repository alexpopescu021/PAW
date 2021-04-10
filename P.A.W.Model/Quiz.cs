using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class Quiz : DataEntity
    {
        public string Question { get; protected set; }

        public string Answer1 { get; protected set; }
        public string Answer2 { get; protected set; }

    }
}
