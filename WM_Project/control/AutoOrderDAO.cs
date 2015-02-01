using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.common;
using WM_Project.control;

namespace WM_Project.control
{
    public class AutoOrderDAO
    {

        //向批量导入的订单表中添加订单
        public bool addAutoOrder(AutoOrder autoOrder)
        {
            bool flag = false;

            string sql = "insert into tb_auto_order values('"+autoOrder.Auto_no+"','"+autoOrder.Name+"','"+autoOrder.Order_time+"',"+autoOrder.Order_count+","+autoOrder.Collection_count+","+autoOrder.Take_charge+",'"+autoOrder.Discount_code+"',"+autoOrder.Discount+","+autoOrder.Pay_before_discount+","+autoOrder.Pay_after_discount+","+autoOrder.Less_pay+",'"+autoOrder.Is_pay+"','"+autoOrder.Pay_way+"','"+autoOrder.Pay_time+"','"+autoOrder.Excel_path+"')";

            if(new DBOperateCommon().excuteNoQuery(sql)){
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 通过 auto_no 来获取订单
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public AutoOrder getAutoOrder(string auto_no)
        {
            AutoOrder order = new AutoOrder();

            string sql = "select * from tb_auto_order where auto_no='" + auto_no + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
               
                order.Auto_no = dr["auto_no"].ToString();
                order.Name = dr["name"].ToString();
                order.Order_time = Convert.ToDateTime(dr["order_time"].ToString()).ToString("yyyy-MM-dd HH:mm");
                order.Order_count = Convert.ToInt32(dr["order_count"].ToString());
                order.Collection_count = Convert.ToInt32(dr["collection_count"].ToString());
                order.Take_charge = Convert.ToSingle(dr["take_charge"].ToString());
                order.Discount_code = dr["discount_code"].ToString();
                order.Discount = Convert.ToSingle(dr["discount"].ToString());
                order.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                order.Is_pay = dr["is_pay"].ToString();
                order.Pay_way = dr["pay_way"].ToString();
                order.Pay_time = dr["pay_time"].ToString();
                order.Excel_path = dr["excel_path"].ToString();
            }

            return order;
        }


        /// <summary>
        /// 通过会员名来获取会员的订单
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pay_status"></param>
        /// <returns></returns>
        public ArrayList getOrdersArray(string name, string pay_status)
        {
            ArrayList orders = new ArrayList();

            string sql = "select * from tb_auto_order where is_pay='" + pay_status + "' and name='" + name + "'  order by order_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrder order = new AutoOrder();

                order.Auto_no = dr["auto_no"].ToString();
                order.Name = dr["name"].ToString();
                order.Order_time = Convert.ToDateTime(dr["order_time"].ToString()).ToString("yyyyMMdd HHmm");
                order.Order_count = Convert.ToInt32(dr["order_count"].ToString());
                order.Collection_count = Convert.ToInt32(dr["collection_count"].ToString());
                order.Take_charge = Convert.ToInt32(dr["take_charge"].ToString());
                order.Discount_code = dr["discount_code"].ToString();
                order.Discount = Convert.ToSingle(dr["discount"].ToString());
                order.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                order.Is_pay = dr["is_pay"].ToString();
                order.Pay_way = dr["pay_way"].ToString();
                order.Pay_time = dr["pay_time"].ToString();
                order.Excel_path = dr["excel_path"].ToString();
                orders.Add(order);

            }

            return orders;

        }


        /// <summary>
        /// 通过用户名来获取用户下单的个数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pay_status"></param>
        /// <returns></returns>
        public int getAUtoOrdersCount(string name,string pay_status)
        {
            int record_count = 0;
            string sql = "select count(*) from tb_auto_order where name='" + name + "' and is_pay='" + pay_status + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                record_count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return record_count;

        }

       /// <summary>
       /// 通过会员名来获取会员的订单
       /// </summary>
       /// <param name="name"></param>
       /// <param name="pay_status"></param>
       /// <returns></returns>
        public ArrayList getOrdersArray(string name, string pay_status,int pageNow,int pageSize)
        {
            ArrayList orders = new ArrayList();

            string sql = "select top " + pageSize + "  * from tb_auto_order where is_pay='" + pay_status + "' and name='" + name + "' and auto_no not in(select top " + (pageNow - 1) * pageSize + " auto_no from tb_auto_order where name='" + name + "' and is_pay='" + pay_status + "' order by pay_time desc)  order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrder order = new AutoOrder();

                order.Auto_no = dr["auto_no"].ToString();
                order.Name = dr["name"].ToString();
                order.Order_time = Convert.ToDateTime(dr["order_time"].ToString()).ToString("yyyyMMdd HHmm");
                order.Order_count = Convert.ToInt32(dr["order_count"].ToString());
                order.Collection_count = Convert.ToInt32(dr["collection_count"].ToString());
                order.Take_charge = Convert.ToInt32(dr["take_charge"].ToString());
                order.Discount_code = dr["discount_code"].ToString();
                order.Discount = Convert.ToSingle(dr["discount"].ToString());
                order.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                order.Is_pay = dr["is_pay"].ToString();
                order.Pay_way = dr["pay_way"].ToString();
                order.Pay_time = dr["pay_time"].ToString();
                order.Excel_path = dr["excel_path"].ToString();
                orders.Add(order);

            }

            return orders;

        }

        /// <summary>
        /// 跟新订单信息表
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns>添加成功返回 true ， 否则返回 false</returns>
        public bool updateAutoOrder(AutoOrder order)
        {
            bool flag = false;

            string sql = "update tb_auto_order set order_time='"+order.Order_time+"', order_count="+order.Order_count+",collection_count="+order.Collection_count+",take_charge="+order.Take_charge+", discount_code='"+order.Discount_code+"' , discount="+order.Discount+", pay_before_discount="+order.Pay_before_discount+", pay_after_discount="+order.Pay_after_discount+", less_pay="+order.Less_pay+" ,is_pay='"+order.Is_pay+"',pay_way='"+order.Pay_way+"', pay_time='"+order.Pay_time+"' where auto_no='"+order.Auto_no+"'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 更新订单的付款状态
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public bool updateAutoOrderPayStatus(string name, string paymethod)
        {
            bool flag = false;
            string pay_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            string update = "update tb_auto_order set is_pay='paied' , pay_time='" + pay_time + "',pay_way='"+paymethod+"' where name='"+name+"' and is_pay='unpay' ";

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 删除一系列订单
        /// </summary>
        /// <param name="auto_no">订单号</param>
        /// <returns></returns>
        public bool deleteAutoOrder(string auto_no)
        {
            bool flag = false;

            string sql = "delete from tb_auto_order where auto_no='" + auto_no + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                string delete = "delete from tb_auto_orderlist where auto_no='" + auto_no + "'";

                if (new DBOperateCommon().excuteNoQuery(delete))
                {
                    flag = true;
                }
            }

            return flag;
        }


        /// <summary>
        /// 删除未付款的订单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool deleteUpayAutoOrder(string name)
        {
            bool flag = false;

            string sql = "delete from tb_orders where name='" + name + "' and is_pay='unpay'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;

                //删除订单对应的包裹
                string del_package = "delete from tb_package where name='"+name+"' and is_pay='unpay'";
                new DBOperateCommon().excuteNoQuery(del_package);
            }

            return flag;
        }

        /// <summary>
        /// 通过起始时间、终止时间、会员名获取订单信息
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="name">会员名</param>
        /// <returns>返回订单信息，将订单信息存放在ArrayList对象中</returns>
        public ArrayList getOrders(string start, string end, string pay_status, int pageNow, int pageSize)
        {
            ArrayList orders = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_auto_order where is_pay='" + pay_status +
                            "' and pay_time>='"+start+"' and pay_time<='"+end+"' and auto_no not in (select top " + (pageNow - 1) * pageSize + " auto_no from tb_auto_order where is_pay='" + pay_status + "' and pay_time>='"+start+"' and pay_time<='"+end+"' order by pay_time desc) order by pay_time desc";


            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrder order = new AutoOrder();

                order.Auto_no = dr["auto_no"].ToString();
                order.Name = dr["name"].ToString();
                order.Order_time = Convert.ToDateTime(dr["order_time"].ToString()).ToString("yyyyMMdd HHmm");
                order.Order_count = Convert.ToInt32(dr["order_count"].ToString());
                order.Collection_count = Convert.ToInt32(dr["collection_count"].ToString());
                order.Take_charge = Convert.ToInt32(dr["take_charge"].ToString());
                order.Discount_code = dr["discount_code"].ToString();
                order.Discount = Convert.ToSingle(dr["discount"].ToString());
                order.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                order.Is_pay = dr["is_pay"].ToString();
                order.Pay_way = dr["pay_way"].ToString();
                order.Pay_time = dr["pay_time"].ToString();

                orders.Add(order);

            }

            return orders;

        }


        /// <summary>
        /// 通过起始时间、终止时间、会员名获取订单信息
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="name">会员名</param>
        /// <returns>返回订单信息，将订单信息存放在ArrayList对象中</returns>
        public ArrayList getOrders(string pay_status, int pageNow, int pageSize)
        {
            ArrayList orders = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_auto_order where is_pay='" + pay_status +
                            "' and auto_no not in (select top " + (pageNow - 1) * pageSize + " auto_no from tb_auto_order where is_pay='" + pay_status + "' order by pay_time desc) order by pay_time desc";


            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrder order = new AutoOrder();

                order.Auto_no = dr["auto_no"].ToString();
                order.Name = dr["name"].ToString();
                order.Order_time = Convert.ToDateTime(dr["order_time"].ToString()).ToString("yyyyMMdd HHmm");
                order.Order_count = Convert.ToInt32(dr["order_count"].ToString());
                order.Collection_count = Convert.ToInt32(dr["collection_count"].ToString());
                order.Take_charge = Convert.ToInt32(dr["take_charge"].ToString());
                order.Discount_code = dr["discount_code"].ToString();
                order.Discount = Convert.ToSingle(dr["discount"].ToString());
                order.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                order.Is_pay = dr["is_pay"].ToString();
                order.Pay_way = dr["pay_way"].ToString();
                order.Pay_time = dr["pay_time"].ToString();

                orders.Add(order);

            }

            return orders;

        }


        /// <summary>
        /// 获取时间段内的记录条数
        /// </summary>
        /// <param name="start_time">开始时间</param>
        /// <param name="end_time">终止时间</param>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public int getRecordCount(string start_time, string end_time, string pay_status)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_auto_order where pay_time>='" + start_time + "' and pay_time<='" +
                end_time + "' and is_pay='" + pay_status + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }


        /// <summary>
        /// 获取记录的条数
        /// </summary>
        /// <param name="pay_status">付款状态</param>
        /// <returns>返回记录的条数</returns>
        public int getRecordCount(string pay_status)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_auto_order where is_pay='"+pay_status+"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if(table.Rows.Count>0){
                recordCount = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return recordCount;

        }

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <param name="recordCount">记录条数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns>返回页数</returns>
        public int getPageCount(int recordCount ,int pageSize)
        {
            int pageCount = 0;

            if (recordCount % pageSize == 0)
            {
                pageCount = recordCount / pageSize;
            }
            else
            {
                pageCount = recordCount / pageSize + 1;
            }

            return pageCount;

        }

    }
}