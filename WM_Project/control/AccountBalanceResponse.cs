using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class AccountBalanceResponse
    {
        private string[] errors;

        public string[] Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        private float accountBalance;

        public float AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }

     
    }
}