﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class AccountBalanceRequest
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}