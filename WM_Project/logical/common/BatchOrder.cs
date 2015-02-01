using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class BatchOrder
    {
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private float length;
        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        private float width;
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        private float height;
        public float Height
        {
            get { return height; }
            set { height = value; }
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

        private string postWay;
        public string PostWay
        {
            get { return postWay; }
            set { postWay = value; }
        }
    }
}