using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class LocalOrder
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string order_no;

        public string Order_no
        {
            get { return order_no; }
            set { order_no = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string collectioncompanyname;

        public string Collectioncompanyname
        {
            get { return collectioncompanyname; }
            set { collectioncompanyname = value; }
        }
        private string collectioncontactname;

        public string Collectioncontactname
        {
            get { return collectioncontactname; }
            set { collectioncontactname = value; }
        }
        private string collectionphone;

        public string Collectionphone
        {
            get { return collectionphone; }
            set { collectionphone = value; }
        }
        private string collectionaddressline;

        public string Collectionaddressline
        {
            get { return collectionaddressline; }
            set { collectionaddressline = value; }
        }
        private string collectiontown;

        public string Collectiontown
        {
            get { return collectiontown; }
            set { collectiontown = value; }
        }
        private string collectionpostcode;

        public string Collectionpostcode
        {
            get { return collectionpostcode; }
            set { collectionpostcode = value; }
        }
        private string collectioncountry;

        public string Collectioncountry
        {
            get { return collectioncountry; }
            set { collectioncountry = value; }
        }

        private string recipientcompanyname;

        public string Recipientcompanyname
        {
            get { return recipientcompanyname; }
            set { recipientcompanyname = value; }
        }
        private string recipientcontactname;

        public string Recipientcontactname
        {
            get { return recipientcontactname; }
            set { recipientcontactname = value; }
        }
        private string recipientphone;

        public string Recipientphone
        {
            get { return recipientphone; }
            set { recipientphone = value; }
        }
        private string recipientaddressline;

        public string Recipientaddressline
        {
            get { return recipientaddressline; }
            set { recipientaddressline = value; }
        }
        private string recipienttown;

        public string Recipienttown
        {
            get { return recipienttown; }
            set { recipienttown = value; }
        }
        private string recipientcountry;

        public string Recipientcountry
        {
            get { return recipientcountry; }
            set { recipientcountry = value; }
        }

        private string recipientpostcode;
        public string Recipientpostcode
        {
            get { return recipientpostcode; }
            set { recipientpostcode = value; }
        }

        private string servicecode;
        public string Servicecode
        {
            get { return servicecode; }
            set { servicecode = value; }
        }

        private string delivery_date;
        public string Delivery_date
        {
            get { return delivery_date; }
            set { delivery_date = value; }
        }

        private string delivery_time;
        public string Delivery_time
        {
            get { return delivery_time; }
            set { delivery_time = value; }
        }

        private string purpose;
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private float estimate_value;
        public float Estimate_value
        {
            get { return estimate_value; }
            set { estimate_value = value; }
        }

        private float insurance;
        public float Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        private string wm_track_no;
        public string Wm_track_no
        {
            get { return wm_track_no; }
            set { wm_track_no = value; }
        }

        private string track_no;
        public string Track_no
        {
            get { return track_no; }
            set { track_no = value; }
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

        private float wm_pay;
        public float Wm_pay
        {
            get { return wm_pay; }
            set { wm_pay = value; }
        }

        private float profit;
        public float Profit
        {
            get { return profit; }
            set { profit = value; }
        }

        private string pay_way;
        public string Pay_way
        {
            get { return pay_way; }
            set { pay_way = value; }
        }

        private string is_pay;
        public string Is_pay
        {
            get { return is_pay; }
            set { is_pay = value; }
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



    }
}