using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class QuotaResponse
    {
        private string[] errors;

        public string[] Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}