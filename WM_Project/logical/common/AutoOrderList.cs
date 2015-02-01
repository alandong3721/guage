using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class AutoOrderList
    {
        private string order_no;
        public string Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }

        private string auto_no;
        public string Auto_no
        {
            get { return auto_no; }
            set { auto_no = value; }
        }

        private string s_track_no;
        public string S_track_no
        {
            get { return s_track_no; }
            set { s_track_no = value; }
        }

        private string cd_track_no;
        public string Cd_track_no
        {
            get { return cd_track_no; }
            set { cd_track_no = value; }
        }

        private string ea_track_no;
        public string Ea_track_no
        {
            get { return ea_track_no; }
            set { ea_track_no = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
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

        private string collectionAddressLine;
        public string CollectionAddressLine
        {
            get { return collectionAddressLine; }
            set { collectionAddressLine = value; }
        }

        private string collectionTown;
        public string CollectionTown
        {
            get { return collectionTown; }
            set { collectionTown = value; }
        }

        private string collectionPostCode;
        public string CollectionPostCode
        {
            get { return collectionPostCode; }
            set { collectionPostCode = value; }
        }

        private string collectionCountry;
        public string CollectionCountry
        {
            get { return collectionCountry; }
            set { collectionCountry = value; }
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

        private string recipientAddressLine;
        public string RecipientAddressLine
        {
            get { return recipientAddressLine; }
            set { recipientAddressLine = value; }
        }

        private string recipientTown;
        public string RecipientTown
        {
            get { return recipientTown; }
            set { recipientTown = value; }
        }

        private string recipientPostCode;
        public string RecipeintPostCode
        {
            get { return recipientPostCode; }
            set { recipientPostCode = value; }
        }

        private string recipientCountry;
        public string RecipientCountry
        {
            get { return recipientCountry; }
            set { recipientCountry = value; }
        }

        private string shippingdate;
        public string Shippingdate
        {
            get { return shippingdate; }
            set { shippingdate = value; }
        }

        private string shippingtype;
        public string Shippingtype
        {
            get { return shippingtype; }
            set { shippingtype = value; }
        }

        private string shippingpurpose;
        public string Shippingpurpose
        {
            get { return shippingpurpose; }
            set { shippingpurpose = value; }
        }

        private string packageDescription;
        public string PackageDescription
        {
            get { return packageDescription; }
            set { packageDescription = value; }
        }

        private float packageValue;
        public float PackageValue
        {
            get { return packageValue; }
            set { packageValue = value; }
        }

        private float insurance;
        public float Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        private string serviceCode;
        public string ServiceCode
        {
            get { return serviceCode; }
            set { serviceCode = value; }
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

        private float volumetric;
        public float Volumetric
        {
            get { return volumetric; }
            set { volumetric = value; }
        }

        private float chargeable;
        public float Chargeable
        {
            get { return chargeable; }
            set { chargeable = value; }
        }

        private float true_weight;
        public float True_weight
        {
            get { return true_weight; }
            set { true_weight = value; }
        }

        private float true_length;
        public float True_length
        {
            get { return true_length; }
            set { true_length = value; }
        }

        private float true_width;
        public float True_width
        {
            get { return true_width; }
            set { true_width = value; }
        }

        private float true_height;
        public float True_height
        {
            get { return true_height; }
            set { true_height = value; }
        }

        private float true_volumetric;
        public float True_volumetric
        {
            get { return true_volumetric; }
            set { true_volumetric = value; }
        }

        private float true_chargeable;
        public float True_chargeable
        {
            get { return true_chargeable; }
            set { true_chargeable = value; }
        }


        private float pay_before_discount;
        public float Pay_before_discount
        {
            get { return pay_before_discount; }
            set { pay_before_discount = value; }
        }

        private float discount;
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private float pay_after_discount;
        public float Pay_after_discount
        {
            get { return pay_after_discount; }
            set { pay_after_discount = value; }
        }

        private float less_pay;
        public float Less_pay
        {
            get { return less_pay; }
            set { less_pay = value; }
        }
        private float profit;
        public float Profit
        {
            get { return profit; }
            set { profit = value; }
        }

        private string pay_status;
        public string Pay_status
        {
            get { return pay_status; }
            set { pay_status = value; }
        }

        private string pay_time;
        public string Pay_time
        {
            get { return pay_time; }
            set { pay_time = value; }
        }

        private string order_time;
        public string Order_time
        {
            get { return order_time; }
            set { order_time = value; }
        }

        private int is_delivery;
        public int Is_delivery
        {
            get { return is_delivery; }
            set { is_delivery = value; }
        }



    }
}