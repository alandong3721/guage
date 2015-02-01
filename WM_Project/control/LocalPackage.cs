using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class LocalPackage
    {


        //包裹编号
        private int package_id;
        public int Package_id
        {
            get { return package_id; }
            set { package_id = value; }
        }

        private string wm_track_no;
        public string Wm_track_no
        {
            get { return wm_track_no; }
            set { wm_track_no = value; }
        }

        //订单号
        private string order_number;
        public string Order_number
        {
            get { return order_number; }
            set { order_number = value; }
        }
        //用户名
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
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

        private string s_track_no;
        public string S_track_no
        {
            get { return s_track_no; }
            set { s_track_no = value; }
        }

        private string local_track;
        public string Local_track
        {
            get { return local_track; }
            set { local_track = value; }
        }


        private string shipmentpurpose;
        public string Shipmentpurpose
        {
            get { return shipmentpurpose; }
            set { shipmentpurpose = value; }
        }
        //包裹描述
        private string packagedescription;
        public string Packagedescription
        {
            get { return packagedescription; }
            set { packagedescription = value; }
        }
        

        //包裹价值
        private float packagevalue;
        public float Packagevalue
        {
            get { return packagevalue; }
            set { packagevalue = value; }
        }
        

        //包裹重量
        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string servicecode;
        public string Servicecode
        {
            get { return servicecode; }
            set { servicecode = value; }
        }

        private string is_pay;
        public string Is_pay
        {
            get { return is_pay; }
            set { is_pay = value; }
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

        
        //保险费
        private float insurance;
        public float Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }


        //实际重量
        private float true_weight;
        public float True_weight
        {
            get { return true_weight; }
            set { true_weight = value; }
        }

        
        //少付款
        private float less_pay;
        public float Less_pay
        {
            get { return less_pay; }
            set { less_pay = value; }
        }

        
    }
}