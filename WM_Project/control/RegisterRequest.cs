using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class RegisterRequest
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string e_mail;

        public string E_mail
        {
            get { return e_mail; }
            set { e_mail = value; }
        }

        private string recommendUser;

        public string RecommendUser
        {
            get { return recommendUser; }
            set { recommendUser = value; }
        }

        private string website;

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        } 
    }
}