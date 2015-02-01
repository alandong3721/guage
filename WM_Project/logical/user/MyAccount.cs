using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class MyAccount
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private float balance;
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        private int points;
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        private int red_packet;
        public int Red_packet
        {
            get { return red_packet; }
            set { red_packet = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private float total_consume;
        public float Total_consume
        {
            get { return total_consume; }
            set { total_consume = value; }
        }

        private string last_order_time;
        public string Last_order_time
        {
            get { return last_order_time; }
            set { last_order_time = value; }
        }

        private int user_status;
        public int User_status
        {
            get { return user_status; }
            set { user_status = value; }
        }

        private int user_level;
        public int User_level
        {
            get { return user_level; }
            set { user_level = value; }
        }

    }
}