﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitter.Model
{
    public class UserDetails
    {
        public string TwitterId { get; set; }        
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }        
        public bool IsAuthenticated
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Token);
            }
        }
    }
}
