using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.control
{
    public class AutoOrderListDAO
    {

        // 向批量导入订单详细信息表中添加 订单详细信息
        public bool addAutoOrderList(AutoOrderList orderlist)
        {
            bool flag = false;

            string sql = "insert into tb_auto_orderlist values('"+orderlist.Order_no+"','"+orderlist.Auto_no+"','"+orderlist.S_track_no+"','"+orderlist.Cd_track_no+"','"+orderlist.Ea_track_no+"','"+orderlist.Name+"','"+orderlist.CollectionCompanyName+"','"+orderlist.CollectionContactName+"','"+
                orderlist.CollectionPhone+"','"+orderlist.CollectionAddressLine+"','"+orderlist.CollectionTown+"','"+orderlist.CollectionPostCode+"','"+orderlist.CollectionCountry+"','"+orderlist.RecipientCompanyName+"','"+
                orderlist.RecipientContactName+"','"+orderlist.RecipientPhone+"','"+orderlist.RecipientAddressLine+"','"+orderlist.RecipientTown+"','"+orderlist.RecipeintPostCode+"','"+orderlist.RecipientCountry+"','"+
                orderlist.Shippingdate+"','"+orderlist.Shippingtype+"','"+orderlist.Shippingpurpose+"','"+orderlist.PackageDescription+"',"+orderlist.PackageValue+","+orderlist.Insurance+",'"+orderlist.ServiceCode+"',"+
                orderlist.Weight+","+orderlist.Length+","+orderlist.Width+","+orderlist.Height+","+orderlist.Volumetric+","+orderlist.Chargeable+","+orderlist.True_weight+","+orderlist.True_length+","+orderlist.True_width+","+
                orderlist.True_height+","+orderlist.True_volumetric+","+orderlist.True_chargeable+",'"+orderlist.Pay_status+"',"+orderlist.Pay_before_discount+","+orderlist.Discount+","+orderlist.Pay_after_discount+",'"+orderlist.Pay_time+"','"+
                orderlist.Order_time+"',"+orderlist.Less_pay+","+orderlist.Profit+","+orderlist.Is_delivery+")";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        //删除未付款单订单
        public bool deleteUpayOrderlist(string name)
        {
            bool flag = false;

            string sql = "delete from tb_auto_orderlist where name='" + name + "' and pay_status='unpay' ";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 通过订单号获取订单详细信息
        /// </summary>
        /// <returns></returns>
        public AutoOrderList getAutoOrderList(string order_no)
        {
            AutoOrderList orderlist = new AutoOrderList();

            string sql = "select * from tb_auto_orderlist where order_no = '" + order_no + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                // 为 orderlist 对象赋值
                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

            }

            return orderlist;
        }

        /// <summary>
        /// 通过追踪号获取订单
        /// </summary>
        /// <param name="track_no"></param>
        /// <returns></returns>
        public AutoOrderList getAutoOrderListByTrackNo(string track_no)
        {
            AutoOrderList orderlist = new AutoOrderList();

            string sql = "select * from tb_auto_orderlist where ea_track_no = '" + track_no + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                // 为 orderlist 对象赋值
                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

            }

            return orderlist;
        }

        /// <summary>
        /// 通过订单号获取订单详细信息
        /// </summary>
        /// <returns></returns>
        public ArrayList getPayAutoOrderList(string order_no)
        {
            ArrayList orderlist_array = new ArrayList();

            string sql = "";
            if (order_no.Contains("AU"))
            {
                sql = "select * from tb_auto_order where auto_no='" + order_no + "'";
            }
            else
            {
                sql = "select * from tb_auto_orderlist where order_no = '" + order_no + "'";
            }
     
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();
                // 为 orderlist 对象赋值
                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                orderlist_array.Add(orderlist);
            }

            return orderlist_array;
        }


        /// <summary>
        /// 通过 auto_no 来获取此次下单的订单
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public ArrayList getAutoOrderListArray(string name,string pay_status,int pageNow,int pageSize)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "' and recipientcountry='China' and order_no not in(select top " + (pageNow - 1) * pageSize + " order_no from tb_auto_orderlist where name='" + name + "' and pay_status='"+pay_status+"' order by pay_time desc) order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }





        /// <summary>
        /// 通过 auto_no 来获取此次下单的订单
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public ArrayList getAutoOrderListArray(string name, string pay_status, int pageNow, int pageSize,string label)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "' and recipientcountry='China' and ea_track_no!='' and order_no not in(select top " + (pageNow - 1) * pageSize + " order_no from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "' and ea_track_no!='' order by pay_time desc) order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }


        //获取需要获取 Label的订单
        public ArrayList getAutoOrderListArrayNeedLabel(string name,string pay_status,string pf_track_no)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select * from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "' and ea_track_no='"+pf_track_no+"' order by order_time desc , order_no asc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }

        /// <summary>
        /// 获取该用户的订单信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pay_status">付款状态</param>
        /// <returns></returns>
        public ArrayList getAutoOrderListArray(string name, string pay_status)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select * from tb_auto_orderlist where name='" + name + "' and pay_status='"+pay_status+"' order by order_time desc , order_no asc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }


        //获取订单的条数
        public int getAutoOrderListRecordCount(string name, string pay_status)
        {
            int record_count = 0;

            string sql = "select count(*) from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                record_count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return record_count;
        }


        //获取订单的条数
        public int getAutoOrderListRecordCount(string name, string pay_status, string label)
        {
            int record_count = 0;

            string sql = "select count(*) from tb_auto_orderlist where name='" + name + "' and pay_status='" + pay_status + "' and ea_track_no!='' ";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                record_count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return record_count;
        }

        /// <summary>
        /// 通过 auto_no 来获取此次下单的订单
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public ArrayList getAutoOrderListArray(string auto_no)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select  * from tb_auto_orderlist where auto_no='" + auto_no + "' order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }

        /// <summary>
        /// 通过单号获取订单信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable getAutoOrderListTable(string number)
        {
            DataTable table = new DataTable();

            if (number.Contains("AU"))
            {
                string sql = "select * from tb_auto_orderlist where auto_no='" + number + "' and is_pay='paied'";
                table = new DBOperateCommon().excuteQuery(sql);

            }
            else if (number.Contains("WP"))
            {
                string sql = "select * from tb_auto_orderlist where order_no='" + number + "' and pay_status='paied'";
                table = new DBOperateCommon().excuteQuery(sql);
            }

            return table;

        }

        /// <summary>
        /// 通过 auto_no 来获取此次下单的订单
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public ArrayList getAutoOrderListArray(string auto_no,int pageNow,int pageSize)
        {
            ArrayList autoArray = new ArrayList();

            string sql = "select top "+pageSize+" * from tb_auto_orderlist where auto_no='" + auto_no + "' and order_no not in(select top "+(pageNow-1)*pageSize+" order_no from tb_auto_orderlist where auto_no='"+auto_no+"') order by pay_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            foreach (DataRow dr in table.Rows)
            {
                AutoOrderList orderlist = new AutoOrderList();

                orderlist.Order_no = dr["order_no"].ToString();
                orderlist.Auto_no = dr["auto_no"].ToString();
                orderlist.S_track_no = dr["s_track_no"].ToString();
                orderlist.Cd_track_no = dr["cd_track_no"].ToString();
                orderlist.Ea_track_no = dr["ea_track_no"].ToString();
                orderlist.Name = dr["name"].ToString();
                orderlist.CollectionCompanyName = dr["collectioncompanyname"].ToString();
                orderlist.CollectionContactName = dr["collectioncontactname"].ToString();
                orderlist.CollectionPhone = dr["collectionphone"].ToString();
                orderlist.CollectionAddressLine = dr["collectionaddressline"].ToString();
                orderlist.CollectionTown = dr["collectiontown"].ToString();
                orderlist.CollectionPostCode = dr["collectionpostcode"].ToString();
                orderlist.CollectionCountry = dr["collectioncountry"].ToString();
                orderlist.RecipientCompanyName = dr["recipientcompanyname"].ToString();
                orderlist.RecipientContactName = dr["recipientcontactname"].ToString();
                orderlist.RecipientPhone = dr["recipientphone"].ToString();
                orderlist.RecipientAddressLine = dr["recipientaddressline"].ToString();
                orderlist.RecipientTown = dr["recipienttown"].ToString();
                orderlist.RecipeintPostCode = dr["recipientpostcode"].ToString();
                orderlist.RecipientCountry = dr["recipientcountry"].ToString();
                orderlist.Shippingdate = dr["shippingdate"].ToString();
                orderlist.Shippingtype = dr["shippingtype"].ToString();
                orderlist.Shippingpurpose = dr["shipmentpurpose"].ToString();
                orderlist.PackageDescription = dr["packagedescription"].ToString();
                orderlist.PackageValue = Convert.ToSingle(dr["packagevalue"].ToString());
                orderlist.Insurance = Convert.ToSingle(dr["insurance"].ToString());
                orderlist.ServiceCode = dr["servicecode"].ToString();
                orderlist.Weight = Convert.ToSingle(dr["weight"].ToString());
                orderlist.Length = Convert.ToSingle(dr["length"].ToString());
                orderlist.Width = Convert.ToSingle(dr["width"].ToString());
                orderlist.Height = Convert.ToSingle(dr["height"].ToString());
                orderlist.Volumetric = Convert.ToSingle(dr["volumetric"].ToString());
                orderlist.Chargeable = Convert.ToSingle(dr["chargeable"].ToString());
                orderlist.True_weight = Convert.ToSingle(dr["true_weight"].ToString());
                orderlist.True_length = Convert.ToSingle(dr["true_length"].ToString());
                orderlist.True_width = Convert.ToSingle(dr["true_width"].ToString());
                orderlist.True_volumetric = Convert.ToSingle(dr["true_volumetric"].ToString());
                orderlist.True_chargeable = Convert.ToSingle(dr["true_chargeable"].ToString());
                orderlist.Pay_status = dr["pay_status"].ToString();
                orderlist.Pay_before_discount = Convert.ToSingle(dr["pay_before_discount"].ToString());
                orderlist.Discount = Convert.ToSingle(dr["discount"].ToString());
                orderlist.Pay_after_discount = Convert.ToSingle(dr["pay_after_discount"].ToString());
                orderlist.Pay_time = dr["pay_time"].ToString();
                orderlist.Order_time = dr["order_time"].ToString();
                orderlist.Less_pay = Convert.ToSingle(dr["less_pay"].ToString());
                orderlist.Profit = Convert.ToSingle(dr["profit"].ToString());
                orderlist.Is_delivery = Convert.ToInt32(dr["is_delivery"].ToString());

                autoArray.Add(orderlist);
            }

            return autoArray;
        }

        /// <summary>
        /// 通过 auto_no 获取此次下单的 包裹个数
        /// </summary>
        /// <param name="auto_no"></param>
        /// <returns></returns>
        public int getRecordCount(string auto_no)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_auto_orderlist where auto_no='" + auto_no + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }

        //获取页数
        public int getPageCount(int recordCount,int pageSize)
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
        /// 跟新付款状态
        /// </summary>
        /// <param name="order_no"></param>
        /// <returns></returns>
        public bool updatePayStatus(string order_no)
        {
            bool flag = false;
            string pay_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            string update = "update tb_auto_orderlist set pay_status='paied' , pay_time='" + pay_time + "' where order_no='"+order_no+"'";

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 查看购物车时更新表
        /// </summary>
        /// <param name="orderlist">订单详细信息表</param>
        /// <returns>更新成功时返回 true ， 否则返回 false</returns>
        public bool updateAutoOrderList(AutoOrderList orderlist)
        {
            bool flag = false;

            string sql = "update tb_auto_orderlist set s_track_no='"+orderlist.S_track_no+"',cd_track_no='"+orderlist.Cd_track_no+"', ea_track_no='"+orderlist.Ea_track_no+"',collectioncompanyname='"+orderlist.CollectionCompanyName+"',collectioncontactname='"+orderlist.CollectionContactName+"',collectionphone='"+orderlist.CollectionPhone+"',collectionaddressline='"+orderlist.CollectionAddressLine+"',collectiontown='"+orderlist.CollectionTown+"',collectionpostcode='"+orderlist.CollectionPostCode+"',collectioncountry='"+orderlist.CollectionCountry+"',recipientcompanyname='"+
                         orderlist.RecipientCompanyName+"',recipientcontactname='"+orderlist.RecipientContactName+"',recipientphone='"+orderlist.RecipientPhone+"',recipientaddressline='"+orderlist.RecipientAddressLine+"',recipienttown='"+orderlist.RecipientTown+"',recipientpostcode='"+orderlist.RecipeintPostCode+"',recipientcountry='"+orderlist.RecipientCountry+"',shippingdate='"+orderlist.Shippingdate+"',shippingtype='"+orderlist.Shippingtype+"',shipmentpurpose='"+orderlist.Shippingpurpose+"',packagedescription='"+
                         orderlist.PackageDescription+"',packagevalue="+orderlist.PackageValue+",insurance="+orderlist.Insurance+",servicecode='"+orderlist.ServiceCode+"',weight="+orderlist.Weight+",length="+orderlist.Length+",width="+orderlist.Width+",height="+orderlist.Height+",volumetric="+orderlist.Volumetric+",chargeable="+orderlist.Chargeable+",true_weight="+orderlist.True_weight+",true_length="+orderlist.True_length+",true_width="+orderlist.True_width+",true_height="+orderlist.True_height+",true_volumetric="+orderlist.True_volumetric+",true_chargeable="+orderlist.True_chargeable+
                         ",pay_status='"+orderlist.Pay_status+"',pay_before_discount="+orderlist.Pay_before_discount+",discount="+orderlist.Discount+",pay_after_discount="+orderlist.Pay_after_discount+",pay_time='"+orderlist.Pay_time+"',order_time='"+orderlist.Order_time+"',less_pay="+orderlist.Less_pay+",profit="+orderlist.Profit+",is_delivery="+orderlist.Is_delivery+" where order_no='"+orderlist.Order_no+"'";

            if(new DBOperateCommon().excuteNoQuery(sql)){
                
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order_no"></param>
        /// <param name="pf_track_no"></param>
        /// <returns></returns>
        public bool updateAutoOrderListTrackNo(string order_no,string s_track_no,string cd_track_no,string ea_track_no)
        {
            bool flag = false;

            string update = "update tb_auto_orderlist set s_track_no='" + s_track_no + "', cd_track_no='"+cd_track_no+"',ea_track_no='"+ea_track_no+"' where order_no='" + order_no + "'";

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 删除订单详细信息列表中的订单
        /// </summary>
        /// <param name="order_no">订单号</param>
        /// <returns>删除成功返回 true ， 否则返回 false</returns>
        public bool deleteAutoOrderList(string order_no)
        {
            bool flag = false;

            AutoOrderList order = getAutoOrderList(order_no);

            string sql = "delete from tb_auto_orderlist where order_no='" + order_no + "'";

            if (new DBOperateCommon().excuteNoQuery(sql)) 
            {
                flag = true;
            }

            AutoOrder auto_order = new AutoOrderDAO().getAutoOrder(order.Auto_no);
            
            if (order.Shippingtype.Contains("取件") || order.Shippingtype.Contains("COLLECTION") || order.Shippingtype.Contains("collection"))
            {
                auto_order.Collection_count = auto_order.Collection_count - 1;
                auto_order.Take_charge = new DeliveryRateDAO().getDeliveryRate(auto_order.Collection_count);
            }

            auto_order.Order_count -= 1;
            auto_order.Pay_before_discount -= order.Pay_before_discount;
            auto_order.Pay_after_discount = auto_order.Pay_before_discount;

            if (auto_order.Order_count == 0)
            {
                new AutoOrderDAO().deleteAutoOrder(auto_order.Auto_no);
            }
            else
            {
                new AutoOrderDAO().updateAutoOrder(auto_order);
            }

            return flag;
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //  is_delivery = 0 表示没有使用本地取件服务


        public DataTable getInnerAutoOrderList(string name ,int pageNow,int pageSize,string start,string end)
        {
            string sql = "select top " + pageSize + " * from tb_auto_orderlist where pay_time>='" + start + "' and pay_time<='" + end 
                + "' and is_delivery=0 and name='"+name+"' and ea_track_no !='' and servicecode in('EMS','PostNL') and order_no not in(select top " + 
                (pageNow - 1) * pageSize + " order_no from tb_auto_orderlist where pay_time>='" + start + "' and pay_time<='" + end + "' and is_delivery=0 and name='" +
                name + "' and ea_track_no !='' and servicecode in('EMS','PostNL') ) ";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }

        /// <summary>
        /// 通过单号获取订单信息
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable getInnerAutoOrderListTable(string number)
        {
            DataTable table = new DataTable();

            if (number.Contains("AU"))
            {
                string sql = "select * from tb_auto_orderlist where auto_no='" + number + "' and is_pay='paied'";
                table = new DBOperateCommon().excuteQuery(sql);

            }
            else if(number.Contains("WP"))
            {
                string sql = "select * from tb_auto_orderlist where order_no='" + number + "' and pay_status='paied'";
                table = new DBOperateCommon().excuteQuery(sql);
            }

            return table;

        }

        /// <summary>
        /// 分页获取一段时间内可能需要本地取件的订单
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public DataTable getInnerAutoOrderList(string name,string start, string end, int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            string sql = "select top " + pageSize + " * from tb_auto_orderlist where pay_time>'" + start + "' and pay_time<='" + end + "' and is_delivery=0 and name='" + name + "' and ea_track_no !='' and servicecode in('EMS','PostNL') and order_no not in(select top " + (pageNow - 1) * pageSize + " order_no from tb_auto_orderlist where pay_time>'" + start + "' and pay_time<='" + end + "' and is_delivery=0 and name='" + name + "' and ea_track_no !='' and servicecode in('EMS','PostNL'))";
            table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }

        /// <summary>
        /// 获取某一时间段内的订单的总条数
        /// </summary>
        /// <param name="start">起始时间</param>
        /// <param name="end">终止时间</param>
        /// <returns></returns>
        public int getInnerAutoOrderListRecordCount(string start, string end,string name)
        {
            int count = 0;

            string sql = "select count(*) from tb_auto_orderlist where pay_time>'" + start + "' and pay_time<='" + end + "' and is_delivery=0 and servicecode in('PostNL','EMS') and name='"+name+"'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0]);
            }

            return count;
        }

    }
}