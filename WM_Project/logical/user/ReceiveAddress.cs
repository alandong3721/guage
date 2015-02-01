using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class ReceiveAddress
    {
        private int addr_id;
        public int Addr_id
        {
            get { return addr_id; }
            set { addr_id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string receiver_name;
        public string Receiver_name
        {
            get { return receiver_name; }
            set { receiver_name = value; }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string province;
        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string area;
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private string street_info;
        public string Street_info
        {
            get { return street_info; }
            set { street_info = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string postcode;
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string e_mail;
        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }

        private string is_default;
        public string Is_default
        {
            get { return is_default; }
            set { is_default = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}