using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class UserDebt
    {
        private string user_name;
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }


        private float amount;
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}