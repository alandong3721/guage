using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class ChangePwdResponse
    {
        private string[] errors;

        public string[] Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}