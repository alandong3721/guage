using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class LocalPackageDAO
    {

        /// <summary>
        /// 添加 本地订单包裹
        /// </summary>
        /// <param name="local_package"></param>
        /// <returns></returns>
        public bool addLocalPackage(LocalPackage local_package)
        {
            bool flag = false;

            string sql = "insert into tb_local_package values('" + local_package.Wm_track_no + "','" + local_package.Order_number + "','" + local_package.Name + "','" + local_package.Cd_track_no + "','" + local_package.Ea_track_no + "','" + local_package.S_track_no + "','"+local_package.Local_track+ "','" + local_package.Shipmentpurpose + "','"
                + local_package.Packagedescription + "'," + local_package.Packagevalue + "," + local_package.Weight + ",'" + local_package.Servicecode + "','" + local_package.Is_pay + "'," + local_package.Insurance + "," + local_package.Pay_before_discount + "," + local_package.Discount + "," + local_package.Pay_after_discount + "," + local_package.Less_pay + "," + local_package.True_weight + ")";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 跟新付款状态
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        public bool updatePayStatus(string order_number)
        {
            bool flag = false;

            string sql = "update tb_local_package set is_pay='paied' where order_no='" + order_number + "'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 删除本地订单包裹
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        public bool deleteLocalPackages(string order_number)
        {
            bool flag = false;

            string sql = "delete from tb_local_package where order_no='" + order_number + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }

        public bool deleteLocalPackagesByName(string name)
        {
            bool flag = false;

            string sql = "delete from tb_local_package where is_pay='unpay' and name='" + name + "'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 通过本地单号获取本地订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public ArrayList getLocalPackageByOrderNo(string orderno)
        {
            ArrayList array = new ArrayList();

            string sql = "select * from tb_local_package where order_no='"+orderno+"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                LocalPackage local_package = new LocalPackage();

                local_package.Wm_track_no = table.Rows[i]["wm_track_no"].ToString();
                local_package.Order_number = table.Rows[i]["order_no"].ToString();
                local_package.Name = table.Rows[i]["name"].ToString();
                local_package.Cd_track_no = table.Rows[i]["cd_track_no"].ToString();
                local_package.Ea_track_no = table.Rows[i]["ea_track_no"].ToString();
                local_package.S_track_no = table.Rows[i]["s_track_no"].ToString();
                local_package.Local_track = table.Rows[i]["local_track"].ToString();
                local_package.Shipmentpurpose = table.Rows[i]["shipmentpurpose"].ToString();
                local_package.Packagedescription = table.Rows[i]["packagedescription"].ToString();
                local_package.Packagevalue = Convert.ToSingle(table.Rows[i]["packagevalue"].ToString());
                local_package.Weight = Convert.ToSingle(table.Rows[i]["package_weight"].ToString());
                local_package.Servicecode = table.Rows[i]["servicecode"].ToString();
                local_package.Is_pay = table.Rows[i]["is_pay"].ToString();
                local_package.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                local_package.Pay_before_discount = Convert.ToSingle(table.Rows[i]["pay_before_discount"].ToString());
                local_package.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                local_package.Pay_after_discount = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
                local_package.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                local_package.True_weight = Convert.ToSingle(table.Rows[i]["true_weight"].ToString());

                array.Add(local_package);

            }

            return array;
        }

        public bool updateLocalTrackNo(LocalPackage local_package)
        {
            bool flag = false;

            string sql = "update tb_local_package set local_track='" + local_package.Local_track + "' where ea_track_no='" + local_package.Ea_track_no+"'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }
    }
}