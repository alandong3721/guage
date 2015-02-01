using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class ChangePwdRequest
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string oldPassword;

        public string OldPassword
        {
            get { return oldPassword; }
            set { oldPassword = value; }
        }

        private string newPassword;

        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value; }
        }

    }
}