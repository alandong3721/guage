using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.logical.common
{
    public class AutoOrder
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string auto_no;
        public string Auto_no
        {
            get { return auto_no; }
            set { auto_no = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string order_time;
        public string Order_time
        {
            get { return order_time; }
            set { order_time = value; }
        }

        private int order_count;
        public int Order_count
        {
            get { return order_count; }
            set { order_count = value; }
        }

        private int collection_count;
        public int Collection_count
        {
            get { return collection_count; }
            set { collection_count = value; }
        }
        //取件费用
        private float take_charge;
        public float Take_charge
        {
            get { return take_charge; }
            set { take_charge = value; }
        }


        private string discount_code;
        public string Discount_code
        {
            get { return discount_code; }
            set { discount_code = value; }
        }

        private float discount;
        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private float pay_before_discount;
        public float Pay_before_discount
        {
            get { return pay_before_discount; }
            set { pay_before_discount = value; }
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

        private string is_pay;
        public string Is_pay
        {
            get { return is_pay; }
            set { is_pay = value; }
        }

        private string pay_way;
        public string Pay_way
        {
            get { return pay_way; }
            set { pay_way = value; }
        }


        private string pay_time;
        public string Pay_time
        {
            get { return pay_time; }
            set { pay_time = value; }
        }

        private string excel_path;
        public string Excel_path
        {
            get { return excel_path; }
            set { excel_path = value; }
        }

    }
}