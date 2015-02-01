using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class Order
    {
        // 订单编号
        private int order_id;
        public int Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        //订单号
        private string order_number;
        public string Order_number
        {
            get { return order_number; }
            set { order_number = value; }
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
        public string RecipientPostCode
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

        //取件方式
        private string delivery_way;
        public string Delivery_way
        {
            get { return delivery_way; }
            set { delivery_way = value; }
        }

        //取件日期
        private string delivery_date;
        public string Delivery_date
        {
            get { return delivery_date; }
            set { delivery_date = value; }
        }

        //取件时间段
        private string delivery_time;
        public string Delivery_time
        {
            get { return delivery_time; }
            set { delivery_time = value; }
        }

        //邮寄目的
        private string purpose;
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        //订单中的包裹描述
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //订单估值
        private float estimate_value;
        public float Estimate_value
        {
            get { return estimate_value; }
            set { estimate_value = value; }
        }

        //订单购买保险
        private float insurance;
        public float Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        //订单中包裹个数
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        //发票信息
        private string invoice;
        public string Invoice
        {
            get { return invoice; }
            set { invoice = value; }
        }

        //服务方式
        private string post_way;
        public string Post_way
        {
            get { return post_way; }
            set { post_way = value; }
        }

        // WM提供的追踪号
        private string wp_track_no;
        public string Wp_track_no
        {
            get { return wp_track_no; }
            set { wp_track_no = value; }
        }

        private float local_pick_pay;
        public float Local_pick_pay
        {
            get { return local_pick_pay; }
            set { local_pick_pay = value; }
        }

        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        //打折前应付款
        private float pay_before_discount;
        public float Pay_before_discount
        {
            get { return pay_before_discount; }
            set { pay_before_discount = value; }
        }

        // 折扣
        private float discount;
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        //打折之后应付款
        private float pay_after_discount;
        public float Pay_after_discount
        {
            get { return pay_after_discount; }
            set { pay_after_discount = value; }
        }

        //因低报而少付款
        private float less_pay;
        public float Less_pay
        {
            get { return less_pay; }
            set { less_pay = value; }
        }

        // Parcelforce 提供的追踪号
        private string pf_track;
        public string Pf_track
        {
            get { return pf_track; }
            set { pf_track = value; }
        }

        // 账单追踪号
        private string bill_track;
        public string Bill_track
        {
            get { return bill_track; }
            set { bill_track = value; }
        }

        // WM所付款
        private float wp_pay;
        public float Wp_pay
        {
            get { return wp_pay; }
            set { wp_pay = value; }
        }

        // 利润
        private float profit;
        public float Profit
        {
            get { return profit; }
            set { profit = value; }
        }

        //付款方式
        private string pay_way;
        public string Pay_way
        {
            get { return pay_way; }
            set { pay_way = value; }
        }

        //付款状态，是否付款
        private string is_pay;
        public string Is_pay
        {
            get { return is_pay; }
            set { is_pay = value; }
        }

        //付款时间
        private string pay_time ;
        public string Pay_time
        {
            get { return pay_time; }
            set { pay_time = value; }
        }

 
        //用户产看自己已购买的订单时是否显示
        private string is_show;
        public string Is_show
        {
            get { return is_show; }
            set { is_show = value; }
        }


        //下单时间
        private DateTime order_time;
        public DateTime Order_time
        {
            get { return order_time; }
            set { order_time = value; }
        }

    }
}