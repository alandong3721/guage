using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class Package
    {
        //包裹编号
        private int package_id;
        public int Package_id
        {
            get { return package_id; }
            set { package_id = value; }
        }

        private string wp_track_no;
        public string Wp_track_no
        {
            get { return wp_track_no; }
            set { wp_track_no = value; }
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

        private string local_track_no;
        public string Local_track_no
        {
            get { return local_track_no; }
            set { local_track_no = value; }
        }

        //包裹描述
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        //包裹价值
        private float package_value;
        public float Package_value
        {
            get { return package_value; }
            set { package_value = value; }
        }

        //包裹重量
        private float weight;
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        //包裹长度
        private float length;
        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        //包裹宽度
        private float width;
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        // 包裹的高度
        private float height;
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        //体积重
        private float volumetric;
        public float Volumetric
        {
            get { return volumetric; }
            set { volumetric = value; }
        }

        //计算价格的重量
        private float chargeable;
        public float Chargeable
        {
            get { return chargeable; }
            set { chargeable = value; }
        }

        //邮费
        private float pay;
        public float Pay
        {
            get { return pay; }
            set { pay = value; }
        }

        //保险费
        private float insurance;
        public float Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        //折扣
        private float discount;
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        // 发件国家
        private string departure;
        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }

        //收件国家
        private string destination;
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        //服务方式
        private string post_way;
        public string Post_way
        {
            get { return post_way; }
            set { post_way = value; }
        }

        //实际重量
        private float true_weight;
        public float True_weight
        {
            get { return true_weight; }
            set { true_weight = value; }
        }

        //实际长度
        private float true_length;
        public float True_length
        {
            get { return true_length; }
            set { true_length = value; }
        }

        // 实际宽度
        private float true_width;
        public float True_width
        {
            get { return true_width; }
            set { true_width = value; }
        }

        //实际高度
        private float true_height;
        public float True_height
        {
            get { return true_height; }
            set { true_height = value; }
        }

        //实际体积中
        private float true_volumetric;
        public float True_volumetric
        {
            get { return true_volumetric; }
            set { true_volumetric = value; }
        }

        //实际付款重量
        private float true_chargeable;
        public float True_chargeable
        {
            get { return true_chargeable; }
            set { true_chargeable = value; }
        }

        
        // 实际应该付款
        private float true_pay;
        public float True_pay
        {
            get { return true_pay; }
            set { true_pay = value; }
        }

        //少付款
        private float less_pay;
        public float Less_pay
        {
            get { return less_pay; }
            set { less_pay = value; }
        }

        private string is_pay;
        public string Is_pay
        {
            get { return is_pay; }
            set { is_pay = value; }
        }


    }
}