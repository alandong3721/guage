using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class Postage
    {
        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        private float rate;
        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }


        private float pickup_fees;
        public float Pickup_fees
        {
            get { return pickup_fees; }
            set { pickup_fees = value; }
        }


        private string departure;
        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }


        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }


        private string post_way;
        public string Post_way
        {
            get { return post_way; }
            set { post_way = value; }
        }


        private int per;
        public int Per
        {
            get { return per; }
            set { per = value; }
        }
    }
}