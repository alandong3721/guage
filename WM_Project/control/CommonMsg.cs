using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class CommonMsg
    {
        private string shiptype;
        public string Shiptype
        {
            get { return shiptype; }
            set { shiptype = value; }
        }

        private string servicecode;
        public string Servicecode
        {
            get { return servicecode; }
            set { servicecode = value; }
        }


        private string ordernumber;
        public string Ordernumber
        {
            get { return ordernumber; }
            set { ordernumber = value; }
        }

        private string recipientCompanyName;
        public string RecipientCompanyName
        {
            get { return recipientCompanyName; }
            set { recipientCompanyName = value; }
        }

        private string recipientContactName;
        public string RecipientContactName
        {
            get { return recipientContactName; }
            set { recipientContactName = value; }
        }

        private string recipientPhone;
        public string RecipientPhone
        {
            get { return recipientPhone; }
            set { recipientPhone = value; }
        }

        private string shippingDate;
        public string ShippingDate
        {
            get { return shippingDate; }
            set { shippingDate = value; }
        }

        private string recipientAddress;
        public string RecipientAddress
        {
            get { return recipientAddress; }
            set { recipientAddress = value; }
        }

        private string recipientTown;
        public string RecipientTown
        {
            get { return recipientTown; }
            set { recipientTown = value; }
        }

        private string recipeintPostCode;
        public string RecipeintPostCode
        {
            get { return recipeintPostCode; }
            set { recipeintPostCode = value; }
        }

        private string recipientCountry;
        public string RecipientCountry
        {
            get { return recipientCountry; }
            set { recipientCountry = value; }
        }

        private string collectionCompanyName;
        public string CollectionCompanyName
        {
            get { return collectionCompanyName; }
            set { collectionCompanyName = value; }
        }

        private string collectionContactName;
        public string CollectionContactName
        {
            get { return collectionContactName; }
            set { collectionContactName = value; }
        }

        private string collectionPhone;
        public string CollectionPhone
        {
            get { return collectionPhone; }
            set { collectionPhone = value; }
        }

        private string collectionAddress;
        public string CollectionAddress
        {
            get { return collectionAddress; }
            set { collectionAddress = value; }
        }

        private string collectionPostCode;
        public string CollectionPostCode
        {
            get { return collectionPostCode; }
            set { collectionPostCode = value; }
        }

        private string collectionTown;
        public string CollectionTown
        {
            get { return collectionTown; }
            set { collectionTown = value; }
        }

        private string collectionCountry;
        public string CollectionCountry
        {
            get { return collectionCountry; }
            set { collectionCountry = value; }
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