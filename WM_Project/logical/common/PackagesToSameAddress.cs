using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class PackagesToSameAddress
    {
        //发件国家
        private string departure;
        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }
        //收件国家
        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        //邮寄方式
        private string postway;
        public string Postway
        {
            get { return postway; }
            set { postway = value; }
        }

        private ArrayList package_Array;
        public ArrayList Package_Array
        {
            get { return package_Array; }
            set { package_Array = value; }
        }


    }
}