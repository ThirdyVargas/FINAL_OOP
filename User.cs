﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProj.FitnessApp
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserData> DataProgress { get; set; } = new List<UserData>();
    }
}
