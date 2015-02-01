using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class MyAccountTrans
    {

        private string user_name;
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private float amout;
        public float Amout
        {
            get { return amout; }
            set { amout = value; }
        }

        private string operation;
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        private float ratio;
        public float Ratio
        {
            get { return ratio; }
            set { ratio = value; }
        }

        private string charge_way;
        public string Charge_way
        {
            get { return charge_way; }
            set { charge_way = value; }
        }

        private string bank_account_number;
        public string Bank_account_number
        {
            get { return bank_account_number; }
            set { bank_account_number = value; }
        }

        private string order_number;
        public string Order_number
        {
            get { return order_number; }
            set { order_number = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}