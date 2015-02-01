using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class PackageCartInfo
    {
        private int package_id;
        public int Package_id
        {
            get { return package_id; }
            set { package_id = value; }
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

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private float value;
        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}