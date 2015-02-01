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
    public class InnerPackageDAO
    {
        /// <summary>
        /// 向本地取件表中添加包裹
        /// </summary>
        /// <param name="package">本地包裹信息</param>
        /// <returns></returns>
        public bool addInnerPackage(InnerLocalPackage package)
        {
            bool flag = false;

            string sql = "insert into tb_inner_packages values('"+package.Local_no+"','"+package.Order_no+"','"+package.Ct_track+"','"+package.Name+"','"
                +package.Collectioncompanyname+"','"+package.Collectioncontactname+"','"+package.Collectionphone+"','"+package.Collectionaddressline+"','"
                +package.Collectiontown+"','"+package.Collectionpostcode+"','"+package.Recipientcompanyname+"','"+package.Recipientcontactname+"','"
                +package.Recipientphone+"','"+package.Recipientaddressline+"','"+package.Recipienttown+"','"+package.Recipientpostcode+"','"
                +package.Shippingdate+"','"+package.Shipmentpurpose+"','"+package.Packagedescription+"',"+package.Packagevalue+","+package.Package_weight+",'"
                +package.Servicecode+"','"+package.Pay_status+"',"+package.Pay_before_discount+","+package.Discount+","+package.Pay_after_discount+",'"
                +package.Pay_time+"','"+package.Order_time.ToString()+"',"+package.Less_pay+","+package.True_weight+","+package.Wm_pay+","+package.Profit+")";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }
        
        /// <summary>
        /// 通过订单号删除订单
        /// </summary>
        /// <param name="order_no">订单号</param>
        /// <returns></returns>
        public bool deleteInnerPackage(string local_no)
        {
            bool flag = false;

            string sql = "delete from tb_inner_packages where local_no='" + local_no + "'";
            if(new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 清空我的本地订单购物车
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public bool deleteMyShoppingCart(string name)
        {
            bool flag = false;

            string sql = "delete from tb_inner_packages where name='" + name + "' and pay_status='unpay'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }
        /// <summary>
        /// 更新本地取件包裹信息
        /// </summary>
        /// <param name="package">本地包裹</param>
        /// <returns></returns>
        public bool updateCartInnerPackage(InnerLocalPackage package)
        {
            bool flag = false;

            string sql = "update tb_inner_packages set collectioncompanyname='" + package.Collectioncompanyname + "',collectioncontactname='" + package.Collectioncontactname + "',collectionphone='" + package.Collectionphone + 
                "',collectionaddressline='" + package.Collectionaddressline + "',collectiontown='" + package.Collectiontown + "',collectionpostcode='" + package.Collectionpostcode + "',shippingdate='" + package.Shippingdate +
                "',shipmentpurpose='" + package.Shipmentpurpose + "',packagedescription='" + package.Packagedescription + "',packagevalue=" + package.Packagevalue 
                + ",package_weight=" + package.Package_weight + " where local_no='" + package.Local_no + "'";
            
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 通过订单号更新订单的付款状态
        /// </summary>
        /// <param name="order_no">订单号</param>
        /// <returns></returns>
        public bool updateInnerPackagePayStatus(string local_no)
        {
            bool flag = false;

            string sql = "update tb_inner_packages set pay_status='paied' where local_no='" + local_no + "'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 通过订单号来获取包裹
        /// </summary>
        /// <param name="order_no"></param>
        /// <returns></returns>
        public InnerLocalPackage getInnerPackage(string local_no)
        {
            InnerLocalPackage package = new InnerLocalPackage();

            string sql = "select * from tb_inner_packages where local_no='" + local_no + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                package.Local_no = table.Rows[0]["local_no"].ToString();
                package.Order_no = table.Rows[0]["order_no"].ToString();
                package.Ct_track = table.Rows[0]["ct_track"].ToString();
                package.Name = table.Rows[0]["name"].ToString();
                package.Collectioncompanyname = table.Rows[0]["collectioncompanyname"].ToString();
                package.Collectioncontactname = table.Rows[0]["collectioncontactname"].ToString();
                package.Collectionphone = table.Rows[0]["collectionphone"].ToString();
                package.Collectionaddressline = table.Rows[0]["collectionaddressline"].ToString();
                package.Collectiontown = table.Rows[0]["collectiontown"].ToString();
                package.Collectionpostcode = table.Rows[0]["collectionpostcode"].ToString();
                package.Recipientcompanyname = table.Rows[0]["recipientcompanyname"].ToString();
                package.Recipientcontactname = table.Rows[0]["recipientcontactname"].ToString();
                package.Recipientphone = table.Rows[0]["recipientphone"].ToString();
                package.Recipientaddressline = table.Rows[0]["recipientaddressline"].ToString();
                package.Recipienttown = table.Rows[0]["recipienttown"].ToString();
                package.Recipientpostcode = table.Rows[0]["recipientpostcode"].ToString();
                package.Shippingdate = table.Rows[0]["shippingdate"].ToString();
                package.Shipmentpurpose = table.Rows[0]["shipmentpurpose"].ToString();
                package.Packagedescription = table.Rows[0]["packagedescription"].ToString();
                package.Packagevalue = Convert.ToSingle(table.Rows[0]["packagevalue"].ToString());
                package.Package_weight = Convert.ToSingle(table.Rows[0]["package_weight"].ToString());
                package.Servicecode = table.Rows[0]["servicecode"].ToString();
                package.Pay_status = table.Rows[0]["pay_status"].ToString();
                package.Pay_before_discount = Convert.ToSingle(table.Rows[0]["pay_before_discount"].ToString());
                package.Discount = Convert.ToSingle(table.Rows[0]["discount"].ToString());
                package.Pay_after_discount = Convert.ToSingle(table.Rows[0]["pay_after_discount"].ToString());
                package.Pay_time = table.Rows[0]["pay_time"].ToString();
                package.Order_time = Convert.ToDateTime(table.Rows[0]["order_time"].ToString());
                package.Less_pay = Convert.ToSingle(table.Rows[0]["less_pay"].ToString());
                package.True_weight = Convert.ToSingle(table.Rows[0]["true_weight"].ToString());
                package.Wm_pay = Convert.ToSingle(table.Rows[0]["wm_pay"].ToString());
                package.Profit = Convert.ToSingle(table.Rows[0]["profit"].ToString());

            }

            return package;
        }

        /// <summary>
        /// 通过用户名获取用户本地未付款的订单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable getUnPayInnerPackageTable(string name)
        {
            string sql = "select * from tb_inner_packages where name='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }


        /// <summary>
        /// 通过用户名获取本地订单
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public ArrayList getUnPayInnerPackageArray(string name)
        {
            ArrayList array = new ArrayList();
            string sql = "select * from tb_inner_packages where name='" + name + "' and pay_status='unpay'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                InnerLocalPackage package = new InnerLocalPackage();

                package.Local_no = table.Rows[i]["local_no"].ToString();
                package.Order_no = table.Rows[i]["order_no"].ToString();
                package.Ct_track = table.Rows[i]["ct_track"].ToString();
                package.Name = table.Rows[i]["name"].ToString();
                package.Collectioncompanyname = table.Rows[i]["collectioncompanyname"].ToString();
                package.Collectioncontactname = table.Rows[i]["collectioncontactname"].ToString();
                package.Collectionphone = table.Rows[i]["collectionphone"].ToString();
                package.Collectionaddressline = table.Rows[i]["collectionaddressline"].ToString();
                package.Collectiontown = table.Rows[i]["collectiontown"].ToString();
                package.Collectionpostcode = table.Rows[i]["collectionpostcode"].ToString();
                package.Recipientcompanyname = table.Rows[i]["recipientcompanyname"].ToString();
                package.Recipientcontactname = table.Rows[i]["recipientcontactname"].ToString();
                package.Recipientphone = table.Rows[i]["recipientphone"].ToString();
                package.Recipientaddressline = table.Rows[i]["recipientaddressline"].ToString();
                package.Recipienttown = table.Rows[i]["recipienttown"].ToString();
                package.Recipientpostcode = table.Rows[i]["recipientpostcode"].ToString();
                package.Shippingdate = table.Rows[i]["shippingdate"].ToString();
                package.Shipmentpurpose = table.Rows[i]["shipmentpurpose"].ToString();
                package.Packagedescription = table.Rows[i]["packagedescription"].ToString();
                package.Packagevalue = Convert.ToSingle(table.Rows[i]["packagevalue"].ToString());
                package.Package_weight = Convert.ToSingle(table.Rows[i]["package_weight"].ToString());
                package.Servicecode = table.Rows[i]["servicecode"].ToString();
                package.Pay_status = table.Rows[i]["pay_status"].ToString();
                package.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                package.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                package.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                package.Pay_time = table.Rows[i]["pay_time"].ToString();
                package.Order_time = Convert.ToDateTime(table.Rows[i]["order_time"].ToString());
                package.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                package.True_weight = Convert.ToSingle(table.Rows[i]["true_weight"].ToString());
                package.Wm_pay = Convert.ToSingle(table.Rows[i]["wm_pay"].ToString());
                package.Profit = Convert.ToSingle(table.Rows[i]["profit"].ToString());

                array.Add(package);
            }

            return array;
        }

        
    }
}