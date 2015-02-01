using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class ReturnOrderList
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string order_number;
        public string Order_number
        {
            get { return order_number; }
            set { order_number = value; }
        }

        private float money;
        public float Money
        {
            get { return money; }
            set { money = value; }
        }
    }
}