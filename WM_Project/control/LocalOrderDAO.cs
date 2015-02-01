using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class LocalOrderDAO
    {

        /// <summary>
        /// 添加本地订单
        /// </summary>
        /// <param name="local_order"></param>
        /// <returns></returns>
        public bool addLocalOrder(LocalOrder local_order)
        {
            bool flag = false;

            string sql = "insert into tb_local_order values('" + local_order.Order_no + "','" + local_order.Name + "','" + local_order.Collectioncompanyname + "','" + local_order.Collectioncontactname + "','" + local_order.Collectionphone + "','" + local_order.Collectionaddressline + "','" +
                local_order.Collectiontown + "','" + local_order.Collectionpostcode + "','" + local_order.Collectioncountry + "','" + local_order.Recipientcompanyname + "','" + local_order.Recipientcontactname + "','" + local_order.Recipientphone + "','" + local_order.Recipientaddressline + "','" +
                local_order.Recipienttown + "','" + local_order.Recipientpostcode + "','" + local_order.Recipientcountry + "','" + local_order.Servicecode + "','" + local_order.Delivery_date + "','" + local_order.Delivery_time + "','" + local_order.Purpose + "','" + local_order.Description + "'," +
                local_order.Estimate_value + "," + local_order.Insurance + "," + local_order.Quantity +","+local_order.Weight+ ",'" + local_order.Wm_track_no + "','" + local_order.Track_no + "'," + local_order.Pay_before_discount + "," + local_order.Discount + "," + local_order.Pay_after_discount + "," + local_order.Less_pay + "," +
                local_order.Wm_pay + "," + local_order.Profit + ",'" + local_order.Pay_way + "','" + local_order.Is_pay + "','" + local_order.Pay_time + "','" + local_order.Order_time + "')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 通过订单号获取本地订单
        /// </summary>
        /// <param name="order_no"></param>
        /// <returns></returns>
        public LocalOrder getLocalOrder(string order_no)
        {
            LocalOrder local_order = new LocalOrder();

            string sql = "select * from tb_local_order where order_no='" + order_no + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                local_order.Id = Convert.ToInt32(table.Rows[0]["order_id"].ToString());
                local_order.Order_no = table.Rows[0]["order_no"].ToString();
                local_order.Name = table.Rows[0]["name"].ToString();

                local_order.Collectioncompanyname = table.Rows[0]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[0]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[0]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[0]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[0]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[0]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[0]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[0]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[0]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[0]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[0]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[0]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[0]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[0]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[0]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[0]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[0]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[0]["purpose"].ToString();
                local_order.Description = table.Rows[0]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[0]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[0]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[0]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[0]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[0]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[0]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[0]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[0]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[0]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[0]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[0]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[0]["profit"].ToString());
                local_order.Pay_way = table.Rows[0]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[0]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[0]["pay_time"].ToString();
                local_order.Order_time = table.Rows[0]["order_time"].ToString();

            }

            return local_order;
        }


        /// <summary>
        /// 获取没有付款的本地订单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList getUnPayLocalOrder(string name)
        {

            ArrayList array = new ArrayList();

            string sql = "select * from tb_local_order where is_pay='unpay' and name='"+name+"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                LocalOrder local_order = new LocalOrder();

                local_order.Id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
                local_order.Order_no = table.Rows[i]["order_no"].ToString();
                local_order.Name = table.Rows[i]["name"].ToString();

                local_order.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[i]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[i]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[i]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[i]["purpose"].ToString();
                local_order.Description = table.Rows[i]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[i]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
                local_order.Pay_way = table.Rows[i]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[i]["pay_time"].ToString();
                local_order.Order_time = table.Rows[i]["order_time"].ToString();

                array.Add(local_order);
            }


            return array;
        }



        /// <summary>
        /// 获取没有付款的本地订单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList getPayLocalOrder(string name)
        {

            ArrayList array = new ArrayList();

            string sql = "select * from tb_local_order where is_pay='paied' and name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                LocalOrder local_order = new LocalOrder();

                local_order.Id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
                local_order.Order_no = table.Rows[i]["order_no"].ToString();
                local_order.Name = table.Rows[i]["name"].ToString();

                local_order.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[i]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[i]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[i]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[i]["purpose"].ToString();
                local_order.Description = table.Rows[i]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[i]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
                local_order.Pay_way = table.Rows[i]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[i]["pay_time"].ToString();
                local_order.Order_time = table.Rows[i]["order_time"].ToString();

                array.Add(local_order);
            }


            return array;
        }

        /// <summary>
        /// 获取没有付款的本地订单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ArrayList getUnpayLocalOrderNumber(string name)
        {

            ArrayList array = new ArrayList();


            string sql = "select order_no from tb_local_order where is_pay='unpay' and name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            
            for (int i = 0; i < table.Rows.Count; i++)
            {
                array.Add(table.Rows[i]["order_no"].ToString());
            }


            return array;
        }

        

        // 本地订单管理
        public ArrayList getLocalArrayListByTime(string name,string start, string end, int page_now, int page_size)
        {
            ArrayList array = new ArrayList();

            string sql = "select top " + page_size + " * from tb_local_order where name='"+name+"' and is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "' and order_id not in(select top " + (page_now - 1) * page_size + " order_id from tb_local_order where  name='"+name+"' and is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "' order by pay_time desc) order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                LocalOrder local_order = new LocalOrder();
                local_order.Id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
                local_order.Order_no = table.Rows[i]["order_no"].ToString();
                local_order.Name = table.Rows[i]["name"].ToString();

                local_order.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[i]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[i]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[i]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[i]["purpose"].ToString();
                local_order.Description = table.Rows[i]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[i]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
                local_order.Pay_way = table.Rows[i]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[i]["pay_time"].ToString();
                local_order.Order_time = table.Rows[i]["order_time"].ToString();

                array.Add(local_order);
            }

            return array;
        }

        public int getLocalCountByTime(string name, string start, string end)
        {
            int count = 0;

            string sql = "select count(*) from tb_local_order where name='" + name + "' and is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }
            return count;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        // 本地订单管理
        public ArrayList getLocalArrayListByTime(string start,string end,int page_now,int page_size)
        {
            ArrayList array = new ArrayList();

            string sql = "select top " + page_size + " * from tb_local_order where is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "' and order_id not in(select top " + (page_now - 1) * page_size + " order_id from tb_local_order where is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "' order by pay_time desc) order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                LocalOrder local_order = new LocalOrder();
                local_order.Id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
                local_order.Order_no = table.Rows[i]["order_no"].ToString();
                local_order.Name = table.Rows[i]["name"].ToString();
                
                local_order.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[i]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[i]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[i]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[i]["purpose"].ToString();
                local_order.Description = table.Rows[i]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[i]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
                local_order.Pay_way = table.Rows[i]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[i]["pay_time"].ToString();
                local_order.Order_time = table.Rows[i]["order_time"].ToString();

                array.Add(local_order);
            }

            return array;
        }

        public int getLocalOrderCountByTime(string start,string end)
        {
            int count = 0;

            string sql = "select count(*) from tb_local_order where is_pay='paied' and pay_time>='" + start + "' and pay_time<='" + end + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }


        public ArrayList getLocalArrayList(int page_now, int page_size)
        {
            ArrayList array = new ArrayList();

            string sql = "select top " + page_size + " * from tb_local_order where is_pay='paied' and order_id not in(select top " + 
                (page_now - 1) * page_size + " order_id from tb_local_order where is_pay='paied' order by pay_time desc) order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                LocalOrder local_order = new LocalOrder();
                local_order.Id = Convert.ToInt32(table.Rows[i]["order_id"].ToString());
                local_order.Order_no = table.Rows[i]["order_no"].ToString();
                local_order.Name = table.Rows[i]["name"].ToString();

                local_order.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                local_order.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                local_order.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                local_order.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                local_order.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                local_order.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                local_order.Collectioncountry = table.Rows[i]["collectioncountry"].ToString();

                local_order.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                local_order.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                local_order.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                local_order.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                local_order.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                local_order.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                local_order.Recipientcountry = table.Rows[i]["recipientcountry"].ToString();

                local_order.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_order.Delivery_date = table.Rows[i]["delivery_date"].ToString();
                local_order.Delivery_time = table.Rows[i]["delivery_time"].ToString();
                local_order.Purpose = table.Rows[i]["purpose"].ToString();
                local_order.Description = table.Rows[i]["description"].ToString();
                local_order.Estimate_value = Convert.ToSingle(table.Rows[i]["estimate_value"].ToString());
                local_order.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_order.Quantity = Convert.ToInt32(table.Rows[i]["quantity"].ToString());
                local_order.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                local_order.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_order.Track_no = table.Rows[i]["track_no"].ToString();
                local_order.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_order.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_order.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_order.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_order.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                local_order.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());
                local_order.Pay_way = table.Rows[i]["pay_way"].ToString();
                local_order.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_order.Pay_time = table.Rows[i]["pay_time"].ToString();
                local_order.Order_time = table.Rows[i]["order_time"].ToString();

                array.Add(local_order);
            }

            return array;
        }
        public int getLocalOrderCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_local_order where is_pay='paied'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }

        public int getLocalOrderPageCount(int recordCount,int pageSize)
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
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool clearMyShoppingCart(string name)
        {
            bool flag = false;

            string sql = "delete from tb_local_order where name='" + name + "' and is_pay='unpay'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;

                //删除本地包裹
                new LocalPackageDAO().deleteLocalPackagesByName(name);
            }


            return flag;
        }


        /// <summary>
        /// 跟新 本地订单 的付款状态
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        public bool updateLocalOrderPayStatus(string name)
        {
            bool flag = false;

            string sql = "update tb_local_order set is_pay='paied' , pay_time='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where name='"+name+"'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;

                string update = "update tb_local_package set is_pay='paied' where name='" + name + "'";
                new DBOperateCommon().excuteQuery(update);
            }

            return flag;
        }
    }
}