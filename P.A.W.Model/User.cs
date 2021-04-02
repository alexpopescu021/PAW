﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PAW.Model
{
    public class User : DataEntity
    {
        public string UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
