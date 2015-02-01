using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using WM_Project.logical.common;


namespace WM_Project.control
{
    public class OrderDAO
    {
        /// <summary>
        /// 通过订单号获取订单信息
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        public Order getOrder(string order_number)
        {
            Order order = new Order();
            string sql = "select * from tb_orders where order_number='" +order_number + "'";
            
            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();
                
                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();
                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());
                
                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();

                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());

                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();
                
            }

            conn.Close();

            return order;
        }

        /// <summary>
        /// 通过会员名获取该会员的所有订单
        /// </summary>
        /// <param name="name">会员名</param>
        /// <returns>将该会员的订单信息保存在ArrayList对象中返回</returns>
        public ArrayList getOrders(string name, string is_pay)
        {
            ArrayList orders = new ArrayList();
            Order order;
            string sql = "select * from tb_orders where name='" + name + "' and is_pay='" + is_pay + "' order by order_time desc";
            
            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();

                orders.Add(order);
            }

            conn.Close();

            return orders;
        }



        
        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="order">订单类对象</param>
        /// <returns></returns>
        public bool addOrder(Order order)
        {
            bool flag = false;
            string sql = "insert into tb_orders values('" + order.Order_number + "','" + order.Name + "','"+order.CollectionCompanyName+"','" + order.CollectionContactName + "','" 
                + order.CollectionPhone +"','" +order.CollectionAddressLine+"','"+order.CollectionTown+"','"+order.CollectionPostCode+"','"+order.CollectionCountry+ "','"
                + order.RecipientCompanyName+"','" + order.RecipientContactName + "','" + order.RecipientPhone + "','"+order.RecipientAddressLine+"','"+order.RecipientTown+"','"+order.RecipientPostCode+"','"+order.RecipientCountry+"','"
                + order.Delivery_way+"','"+order.Delivery_date+"','"+order.Delivery_time+"','"+order.Purpose+"','"+order.Description+"',"+order.Estimate_value+","+order.Insurance+ "," + order.Quantity + ",'"+order.Invoice+"','"+order.Post_way+"','" 
                + order.Wp_track_no + "',"+order.Local_pick_pay+"," +order.Weight +"," + order.Pay_before_discount+","+order.Discount+","+order.Pay_after_discount+","+order.Less_pay+",'"+order.Pf_track+"','"+order.Bill_track+"',"+order.Wp_pay+","+order.Profit+",'"+order.Pay_way+"','"
                +order.Is_pay+"','"+order.Pay_time+"','"+order.Is_show+"','"+order.Order_time.ToString()+"')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// 删除没有付款的订单 直接删除，删除订单信息的同时，必须将该订单相关联的包裹信息删除
        /// </summary>
        /// <param name="order_number">订单号</param>
        /// <returns>删除成功返回True，否则返回false</returns>
        public bool deleteUnPayOrder(string order_number)
        {
            bool flag = false;

            string sql = "delete from tb_orders where order_number='" + order_number + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
                string delete_package = "delete from tb_package where order_number='" + order_number +"'";
                new DBOperateCommon().excuteNoQuery(delete_package);
            }

            return flag;
        }


        /// <summary>
        /// 删除已付款的订单信息，实际上没有删除，只是让其不显示给用户看
        /// </summary>
        /// <param name="order_number">订单号</param>
        /// <returns>删除成功返回 true，删除失败返回 false</returns>
        public bool deletePayOrder(string order_number)
        {
            bool flag = false;

            string sql = "update is_show='false' where order_number='" + order_number + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 将未付款的订单跟新为付款
        /// </summary>
        /// <param name="order_number">订单号</param>
        /// <returns></returns>
        public bool updatePayStatue(string order_number,string pay_way)
        {
            bool flag = false;

            string sql = "update tb_orders set is_pay='paied' ,  pay_time='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"',pay_way='"+pay_way+"' where order_number='" + order_number + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;

                //将该订单对应的包裹付款状态更改为 paied
                string update_package = "update tb_package set is_pay='paied' where order_number='"+order_number+"'";
                new DBOperateCommon().excuteNoQuery(update_package);
            }

            return flag;
        }



        /// <summary>
        /// 获取指定条数的订单信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pay_status"></param>
        /// <param name="count">所要获取的订单条数</param>
        /// <returns></returns>
        public ArrayList getOrders(string name, string is_pay, int count)
        {
            ArrayList orders = new ArrayList();
            Order order;
            string sql = "select top " + count + " * from tb_orders where name='" + name + "' and is_pay='" + is_pay + "' order by order_time desc";

            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();
                
                orders.Add(order);
            }

            conn.Close();

            return orders;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //分页的实现
        /// <summary>
        /// 获取总记录的条数
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public int getRecordCount(string name,string is_pay) 
        {
            int recordCount = 0;
            string sql = "select count(*) from tb_orders where name='" + name + "' and is_pay='" + is_pay + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <param name="recordCount">记录总数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns>返回页数</returns>
        public int getPageCount(int recordCount,int pageSize)
        {
            int pageCount = 0;

            if(recordCount%pageSize==0)
            {
                pageCount = recordCount / pageSize;
            }
            else
            {
                pageCount = recordCount / pageSize + 1;
            }

            return pageCount;
        }

        /// <summary>
        /// 获取当前页面所要显示的订单条数
        /// </summary>
        /// <param name="name">会员名</param>
        /// <param name="pay_status">付款状态</param>
        /// <param name="page_size">每页显示的条数</param>
        /// <param name="pageNow">当前页码</param>
        /// <returns></returns>
        public ArrayList getOrders(string name, string is_pay, int page_size,int pageNow)
        {
            ArrayList orders = new ArrayList();
            Order order;
            string sql = "select top " + page_size + " * from tb_orders where name='" + name + "' and is_pay='" + is_pay +
                            "' and order_number not in (select top "+(pageNow-1)*page_size+" order_number from tb_orders where name='"+name+"' and is_pay='"+is_pay+"' ) order by order_time desc";

            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();
               
                orders.Add(order);
            }

            conn.Close();

            return orders;
        }


       

        /// <summary>
        /// 获取时间段内的记录条数
        /// </summary>
        /// <param name="start_time">开始时间</param>
        /// <param name="end_time">终止时间</param>
        /// <param name="name">用户名</param>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public int getRecordCount(string start_time, string end_time, string name, string is_pay)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_orders where name='" + name + "' and order_time>='"+ start_time + "' and order_time<='" +
                end_time + "' and is_pay='" + is_pay + "' and is_show='true'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }


        /// <summary>
        /// 通过起始时间、终止时间、会员名获取订单信息
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="name">会员名</param>
        /// <returns>返回订单信息，将订单信息存放在ArrayList对象中</returns>
        public ArrayList getOrders(string start, string end, string name, string is_pay, int pageNow, int pageSize)
        {
            ArrayList orders = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_orders  where order_time>='" + start + "' and order_time<='" +
                         end + "' and is_pay='" + is_pay + "' and name='" + name + "' and order_number not in (select top " + (pageNow - 1) * pageSize + " order_number from tb_orders  where order_time>='" + start + "' and order_time<='" + end + "' and is_pay='" + is_pay + "' and name='" + name + "' ) order by order_time desc";


            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Order order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();


                orders.Add(order);
            }

            conn.Close();


            return orders;
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        // 管理员查看订单信息的操作

        /// <summary>
        /// 获取当前页面所要显示的订单条数
        /// </summary>
        /// <param name="name">会员名</param>
        /// <param name="pay_status">付款状态</param>
        /// <param name="page_size">每页显示的条数</param>
        /// <param name="pageNow">当前页码</param>
        /// <returns></returns>
        public ArrayList getOrders(string is_pay, int page_size, int pageNow)
        {
            ArrayList orders = new ArrayList();
            Order order;
            string sql = "select top " + page_size + " * from tb_orders where is_pay='" + is_pay +
                            "' and order_number not in (select top " + (pageNow - 1) * page_size + " order_number from tb_orders where is_pay='" + is_pay + "' order by order_time desc) order by order_time desc";

            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());
                order.Is_show = sdr["is_show"].ToString();

                orders.Add(order);
            }

            conn.Close();

            return orders;
        }

        /// <summary>
        /// 获取记录的条数
        /// </summary>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public int getRecordCount(string is_pay)
        {
            int count = 0;

            string sql = "select count(*) from tb_orders where is_pay='" + is_pay + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }



        /// <summary>
        /// 通过起始时间、终止时间、会员名获取订单信息
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="name">会员名</param>
        /// <returns>返回订单信息，将订单信息存放在ArrayList对象中</returns>
        public ArrayList getOrderByTime(string start, string end, string is_pay, int pageNow, int pageSize)
        {
            ArrayList orders = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_orders  where order_time>='" + start + "' and order_time<='" +
                         end + "' and is_pay='" + is_pay + "' and  order_number not in (select top " + (pageNow - 1) * pageSize + " order_number from tb_orders  where order_time>='" + start + "' and order_time<='" + end + "' and is_pay='" + is_pay + "' order by order_time desc) order by order_time desc";


            SqlConnection conn = DBConn.getConn();
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Order order = new Order();

                order.Order_id = Convert.ToInt32(sdr["order_id"].ToString());
                order.Order_number = sdr["order_number"].ToString();
                order.Name = sdr["name"].ToString();

                order.CollectionCompanyName = sdr["collectioncompanyname"].ToString();
                order.CollectionContactName = sdr["collectioncontactname"].ToString();
                order.CollectionPhone = sdr["collectionphone"].ToString();
                order.CollectionAddressLine = sdr["collectionaddressline"].ToString();
                order.CollectionTown = sdr["collectiontown"].ToString();
                order.CollectionPostCode = sdr["collectionpostcode"].ToString();
                order.CollectionCountry = sdr["collectioncountry"].ToString();

                order.RecipientCompanyName = sdr["recipientcompanyname"].ToString();
                order.RecipientContactName = sdr["recipientcontactname"].ToString();
                order.RecipientPhone = sdr["recipientphone"].ToString();
                order.RecipientAddressLine = sdr["recipientaddressline"].ToString();
                order.RecipientTown = sdr["recipienttown"].ToString();
                order.RecipientPostCode = sdr["recipientpostcode"].ToString();
                order.RecipientCountry = sdr["recipientcountry"].ToString();

                order.Delivery_way = sdr["delivery_way"].ToString();
                order.Delivery_date = sdr["delivery_date"].ToString();
                order.Delivery_time = sdr["delivery_time"].ToString();

                order.Purpose = sdr["purpose"].ToString();
                order.Description = sdr["description"].ToString();
                order.Estimate_value = Convert.ToSingle(sdr["estimate_value"].ToString());
                order.Insurance = Convert.ToSingle(sdr["insurance"].ToString());
                order.Quantity = Convert.ToInt32(sdr["quantity"].ToString());

                order.Invoice = sdr["invoice"].ToString();
                order.Post_way = sdr["post_way"].ToString();
                order.Wp_track_no = sdr["wp_track_no"].ToString();
                order.Local_pick_pay = Convert.ToSingle(sdr["local_pick_pay"].ToString());
                order.Weight = Convert.ToSingle(sdr["weight"].ToString());
                order.Pay_before_discount = Convert.ToSingle(sdr["pay_before_discount"].ToString());
                order.Discount = Convert.ToSingle(sdr["discount"].ToString());
                order.Pay_after_discount = Convert.ToSingle(sdr["pay_after_discount"].ToString());
                order.Less_pay = Convert.ToSingle(sdr["less_pay"].ToString());
                order.Pf_track = sdr["pf_track"].ToString();
                order.Bill_track = sdr["bill_track"].ToString();
                order.Wp_pay = Convert.ToSingle(sdr["wp_pay"].ToString());
                order.Profit = Convert.ToSingle(sdr["profit"].ToString());
                order.Pay_way = sdr["pay_way"].ToString();
                order.Is_pay = sdr["is_pay"].ToString();
                order.Pay_time = sdr["pay_time"].ToString();
                order.Is_show = sdr["is_show"].ToString();
                order.Order_time = Convert.ToDateTime(sdr["order_time"].ToString());

                orders.Add(order);
            }

            conn.Close();


            return orders;
        }

        /// <summary>
        /// 获取时间段内的记录条数
        /// </summary>
        /// <param name="start_time">开始时间</param>
        /// <param name="end_time">终止时间</param>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public int getRecordCount(string start_time, string end_time, string is_pay)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_orders where order_time>='" + start_time + "' and order_time<='" +
                end_time + "' and is_pay='" + is_pay + "' and is_show='true'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }



        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        //public ArrayList getOrderByTime(string start, string end, string is_pay, int page_now, int page_size)
        //{
        //    ArrayList array = new ArrayList();

        //    string sql = "select top " + page_size + " * from tb_orders where is_pay='"+is_pay+"' and pay_time>='"+start+"' and pay_time<='"+end+"' and order_number not in(select top "+(page_now)*page_size+" order_number from tb_orders where is_pay='"+is_pay+"' and pay_time>='"+start+"' and pay_time<='"+end+"')";
        //    DataTable table = new DBOperateCommon().excuteQuery(sql);

        //    for (int i = 0; i < table.Rows.Count;i++ )
        //    {
        //        Order order = new Order();
        //        order.Order_id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
        //        order.Order_number = table.Rows[i]["order_number"].ToString();
        //        order.Name = table.Rows[i]["name"].ToString();

        //        order.CollectionCompanyName = table.Rows[i]["collectioncompanyname"].ToString();
        //        order.CollectionContactName = table.Rows[i]["collectioncontactname"].ToString();
        //        order.CollectionPhone = table.Rows[i]["collectionphone"].ToString();
        //        order.CollectionAddressLine = table.Rows[i]["collectionaddressline"].ToString();
        //        order.CollectionTown = table.Rows[i]["collectiontown"].ToString();
        //        order.CollectionPostCode = table.Rows[i]["collectionpostcode"].ToString();
        //        order.CollectionCountry = table.Rows[i]["collectioncountry"].ToString();

        //        order.RecipientCompanyName = table.Rows[i]["recipientcompanyname"].ToString();
        //        order.RecipientContactName = table.Rows[i]["recipientcontactname"].ToString();
        //        order.RecipientPhone = table.Rows[i]["recipientphone"].ToString();
        //        order.RecipientAddressLine = table.Rows[i]["recipientaddressline"].ToString();
        //        order.RecipientTown = table.Rows[i]["recipienttown"].ToString();
        //        order.RecipientPostCode = table.Rows[i]["recipientpostcode"].ToString();
        //        order.RecipientCountry = table.Rows[i]["recipientcountry"].ToString();

        //        order.Delivery_way = table.Rows[i]["delivery_way"].ToString();
        //        order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
        //        order.Delivery_time = table.Rows[i]["delivery_time"].ToString();

        //        order.Purpose = table.Rows[i]["purpose"].ToString();
        //        order.Description = table.Rows[i]["description"].ToString();
        //        order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
        //        order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
        //        order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());

        //        order.Invoice = table.Rows[i]["invoice"].ToString();
        //        order.Post_way = table.Rows[i]["post_way"].ToString();
        //        order.Wp_track_no = table.Rows[i]["wp_track_no"].ToString();
        //        order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
        //        order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
        //        order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
        //        order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
        //        order.Pf_track = table.Rows[i]["pf_track"].ToString();
        //        order.Bill_track = table.Rows[i]["bill_track"].ToString();
        //        order.Wp_pay = Convert.ToSingle(table.Rows[i]["wp_pay"].ToString());
        //        order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
        //        order.Pay_way = table.Rows[i]["pay_way"].ToString();
        //        order.Is_pay = table.Rows[i]["is_pay"].ToString();
        //        order.Pay_time = table.Rows[i]["pay_time"].ToString();
        //        order.Order_time = Convert.ToDateTime(table.Rows[i]["order_time"].ToString());
        //        order.Is_show = table.Rows[i]["is_show"].ToString();

        //        array.Add(order);
        //    }

        //    return array;
        //}


        /// <summary>
        /// 跟新订单的追踪号
        /// </summary>
        /// <param name="order_no"></param>
        /// <param name="track_no"></param>
        /// <returns></returns>
        public bool updateTrackNo(string order_no, string track_no)
        {
            bool flag = false;

            string sql = "update tb_orders set pf_track='" + track_no + "' where order_number='" + order_no + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;  
            }

            return flag;
        }

    }
}