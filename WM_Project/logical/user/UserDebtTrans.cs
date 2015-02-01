using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class UserDebtTrans
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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

        private string operation;
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }

        private DateTime operation_time;
        public DateTime Operation_time
        {
            get { return operation_time; }
            set { operation_time = value; }
        }

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

    }
}