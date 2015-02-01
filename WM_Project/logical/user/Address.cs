using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class Address
    {
        private int addr_id;
        public int Addr_id
        {
            get { return addr_id; }
            set { addr_id = value; }
        }

        private string user_name;
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        private string company_name;
        public string Company_name
        {
            get { return company_name; }
            set { company_name = value; }
        }

        private string addr_type;
        public string Addr_type
        {
            get { return addr_type; }
            set { addr_type = value; }
        }

        private string addr_contact;
        public string Addr_contact
        {
            get { return addr_contact; }
            set { addr_contact = value; }
        }

        private string addr_line1;
        public string Addr_line1
        {
            get { return addr_line1; }
            set { addr_line1 = value; }
        }

        private string addr_line2;
        public string Addr_line2
        {
            get { return addr_line2; }
            set { addr_line2 = value; }
        }

        private string addr_line3;
        public string Addr_line3
        {
            get { return addr_line3; }
            set { addr_line3 = value; }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string post_code;
        public string Post_code
        {
            get { return post_code; }
            set { post_code = value; }
        }

        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        private string is_default;
        public string Is_default
        {
            get { return is_default; }
            set { is_default = value; }
        }

    }
}