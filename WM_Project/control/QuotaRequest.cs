using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class QuotaRequest
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

      
        private string destination;

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
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
        private string post_way;

        public string Post_way
        {
            get { return post_way; }
            set { post_way = value; }
        }
    }
}