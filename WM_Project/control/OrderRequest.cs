using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class OrderRequest
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string senderContactName;

        public string SenderContactName
        {
            get { return senderContactName; }
            set { senderContactName = value; }
        }

       
        private string senderCompanyname;

        public string SenderCompanyname
        {
            get { return senderCompanyname; }
            set { senderCompanyname = value; }
        }


        private string senderContry;

        public string SenderContry
        {
            get { return senderContry; }
            set { senderContry = value; }
        }

        private string senderPhone;

        public string SenderPhone
        {
            get { return senderPhone; }
            set { senderPhone = value; }
        }

        private string senderPostCode;

        public string SenderPostCode
        {
            get { return senderPostCode; }
            set { senderPostCode = value; }
        }

        private string senderCity;

        public string SenderCity
        {
            get { return senderCity; }
            set { senderCity = value; }
        }

        private string senderAddress;

        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }

        private string recipientContactName;

        public string RecipientContactName
        {
            get { return recipientContactName; }
            set { recipientContactName = value; }
        }

     

        private string recipientCompanyName;

        public string RecipientCompanyName
        {
            get { return recipientCompanyName; }
            set { recipientCompanyName = value; }
        }

        private string recipientCountry;

        public string RecipientCountry
        {
            get { return recipientCountry; }
            set { recipientCountry = value; }
        }

        private string recipientPhone;

        public string RecipientPhone
        {
            get { return recipientPhone; }
            set { recipientPhone = value; }
        }

        private string recipientCity;

        public string RecipientCity
        {
            get { return recipientCity; }
            set { recipientCity = value; }
        }

        private string recipeintPostCode;

        public string RecipeintPostCode
        {
            get { return recipeintPostCode; }
            set { recipeintPostCode = value; }
        }

        private string recipientAddress;

        public string RecipientAddress
        {
            get { return recipientAddress; }
            set { recipientAddress = value; }
        }

        private string shippingtype;

        public string Shippingtype
        {
            get { return shippingtype; }
            set { shippingtype = value; }
        }

        private string serviceCode;

        public string ServiceCode
        {
            get { return serviceCode; }
            set { serviceCode = value; }
        }

        private string shippingdate;

        public string Shippingdate
        {
            get { return shippingdate; }
            set { shippingdate = value; }
        }

        private int items;

        public int Items
        {
            get { return items; }
            set { items = value; }
        }

        private float[] weight;

        public float[] Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private float[] width;

        public float[] Width
        {
            get { return width; }
            set { width = value; }
        }

        private float[] height;

        public float[] Height
        {
            get { return height; }
            set { height = value; }
        }

        private float[] length;

        public float[] Length
        {
            get { return length; }
            set { length = value; }
        }

        private string[] purposeOfShipment;

        public string[] PurposeOfShipment
        {
            get { return purposeOfShipment; }
            set { purposeOfShipment = value; }
        }

        private string[] description;

        public string[] Description
        {
            get { return description; }
            set { description = value; }
        }
        private float[] value;

        public float[] Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}