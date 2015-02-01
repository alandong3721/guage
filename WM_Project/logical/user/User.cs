using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.user
{
    public class User
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string recommandUser;
        public string RecommandUser
        {
            get { return recommandUser; }
            set { recommandUser = value; }
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

        private DateTime regist_time;
        public DateTime Regist_time
        {
            get { return regist_time; }
            set { regist_time = value; }
        }


        private string delivery;
        public string Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }

        //支付成功码
        private string success_code;
        public string Success_code
        {
            get { return success_code; }
            set { success_code = value; }
        }

        //充值金额
        private float charge_amount;
        public float Charge_amount
        {
            get { return charge_amount; }
            set { charge_amount = value; }
        }

    }
}