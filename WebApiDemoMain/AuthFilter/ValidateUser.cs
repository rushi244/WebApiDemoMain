﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemoMain.AuthFilter
{
    public class ValidateUser
    {
        public static bool Login(string username,string password)
        {
            if(username=="admin" && password == "password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}