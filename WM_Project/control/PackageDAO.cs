using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.common;

namespace WM_Project.control
{
    public class PackageDAO
    {
        /// <summary>
        /// 添加包裹
        /// </summary>
        /// <param name="package">包裹对象</param>
        /// <returns>添加成功返回 True，添加失败返回 False</returns>
        public bool addPackage(Package package)
        {
            bool flag = false;

            string sql = "insert into tb_package values('" +package.Wp_track_no + "','" + package.Order_number +"','"+ package.Name + "','"+package.S_track_no+"','"+package.Cd_track_no+"','"+package.Ea_track_no+"','"+package.Local_track_no+"','"+ package.Description + "'," + package.Package_value + "," + package.Weight
                +","+package.Length+","+package.Width+","+package.Height+","+package.Volumetric+","+package.Chargeable+","+package.Pay+","+package.Insurance+","+package.Discount+",'"+package.Departure+"','"+package.Destination+"','"+package.Post_way+"',"+package.True_weight+","
                + package.True_length + "," + package.True_width + "," + package.True_height +","+package.True_volumetric+","+package.True_chargeable+ "," + package.True_pay + "," + package.Less_pay + ",'"+package.Is_pay+ "')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        /// <summary>
        /// 通过追踪号获取订单信息
        /// </summary>
        /// <param name="track_no"></param>
        /// <returns></returns>
        public Package getPackageByTrackNo(string track_no)
        {
            Package package = new Package();

            string sql = "select * from tb_package where ea_track_no='" + track_no + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                package.Package_id = Convert.ToInt32(table.Rows[0]["package_id"].ToString());
                package.Wp_track_no = table.Rows[0]["wp_track_no"].ToString();
                package.Order_number = table.Rows[0]["order_number"].ToString();
                package.Name = table.Rows[0]["name"].ToString();
                package.S_track_no = table.Rows[0]["s_track_no"].ToString();
                package.Cd_track_no = table.Rows[0]["cd_track_no"].ToString();
                package.Ea_track_no = table.Rows[0]["ea_track_no"].ToString();
                package.Local_track_no = table.Rows[0]["local_track_no"].ToString();

                package.Description = table.Rows[0]["description"].ToString();
                package.Package_value = Convert.ToSingle(table.Rows[0]["package_value"].ToString());
                package.Weight = Convert.ToSingle(table.Rows[0]["weight"].ToString());
                package.Length = Convert.ToSingle(table.Rows[0]["length"].ToString());
                package.Width = Convert.ToSingle(table.Rows[0]["width"].ToString());
                package.Height = Convert.ToSingle(table.Rows[0]["height"].ToString());
                package.Volumetric = Convert.ToSingle(table.Rows[0]["volumetric"].ToString());
                package.Chargeable = Convert.ToSingle(table.Rows[0]["chargeable"].ToString());
                package.Pay = Convert.ToSingle(table.Rows[0]["pay"].ToString());
                package.Insurance = Convert.ToSingle(table.Rows[0]["insurance"].ToString());
                package.Discount = Convert.ToSingle(table.Rows[0]["discount"].ToString());
                package.Departure = table.Rows[0]["departure"].ToString();
                package.Destination = table.Rows[0]["destination"].ToString();
                package.Post_way = table.Rows[0]["post_way"].ToString();
                package.True_weight = Convert.ToSingle(table.Rows[0]["true_weight"].ToString());
                package.True_length = Convert.ToSingle(table.Rows[0]["true_length"].ToString());
                package.True_width = Convert.ToSingle(table.Rows[0]["true_width"].ToString());
                package.True_height = Convert.ToSingle(table.Rows[0]["true_height"].ToString());
                package.True_volumetric = Convert.ToSingle(table.Rows[0]["true_volumetric"].ToString());
                package.True_chargeable = Convert.ToSingle(table.Rows[0]["true_chargeable"].ToString());
                package.True_pay = Convert.ToSingle(table.Rows[0]["true_pay"].ToString());
                package.Less_pay = Convert.ToSingle(table.Rows[0]["less_pay"].ToString());
                package.Is_pay = table.Rows[0]["is_pay"].ToString();
            }

            return package;
        }
        /// <summary>
        /// 通过订单号来获取该订单的 包裹信息
        /// </summary>
        /// <param name="order_number">订单号</param>
        /// <returns>将获得的包裹信息存放在ArrayList对象中</returns>
        public ArrayList getPackage(string order_number)
        {
            ArrayList packages = new ArrayList();

            string sql = "select * from tb_package where order_number='" + order_number + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                Package package = new Package();
                package.Package_id = Convert.ToInt32(table.Rows[i]["package_id"].ToString());
                package.Wp_track_no = table.Rows[i]["wp_track_no"].ToString();
                package.Order_number = table.Rows[i]["order_number"].ToString();
                package.Name = table.Rows[i]["name"].ToString();
                package.S_track_no = table.Rows[i]["s_track_no"].ToString();
                package.Cd_track_no = table.Rows[i]["cd_track_no"].ToString();
                package.Ea_track_no = table.Rows[i]["ea_track_no"].ToString();
                package.Local_track_no = table.Rows[i]["local_track_no"].ToString();

                package.Description = table.Rows[i]["description"].ToString();
                package.Package_value = Convert.ToSingle(table.Rows[i]["package_value"].ToString());
                package.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                package.Length = Convert.ToSingle(table.Rows[i]["length"].ToString());
                package.Width = Convert.ToSingle(table.Rows[i]["width"].ToString());
                package.Height = Convert.ToSingle(table.Rows[i]["height"].ToString());
                package.Volumetric = Convert.ToSingle(table.Rows[i]["volumetric"].ToString());
                package.Chargeable = Convert.ToSingle(table.Rows[i]["chargeable"].ToString());
                package.Pay = Convert.ToSingle(table.Rows[i]["pay"].ToString());
                package.Insurance=Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                package.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                package.Departure = table.Rows[i]["departure"].ToString();
                package.Destination = table.Rows[i]["destination"].ToString();
                package.Post_way = table.Rows[i]["post_way"].ToString();
                package.True_weight = Convert.ToSingle(table.Rows[i]["true_weight"].ToString());
                package.True_length = Convert.ToSingle(table.Rows[i]["true_length"].ToString());
                package.True_width = Convert.ToSingle(table.Rows[i]["true_width"].ToString());
                package.True_height = Convert.ToSingle(table.Rows[i]["true_height"].ToString());
                package.True_volumetric = Convert.ToSingle(table.Rows[i]["true_volumetric"].ToString());
                package.True_chargeable = Convert.ToSingle(table.Rows[i]["true_chargeable"].ToString());
                package.True_pay = Convert.ToSingle(table.Rows[i]["true_pay"].ToString());
                package.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                package.Is_pay = table.Rows[i]["is_pay"].ToString();

                packages.Add(package);
            }

            return packages;
        }

        /// <summary>
        /// 获取修改购物车信息所需要的包裹信息
        /// </summary>
        /// <returns></returns>
        public ArrayList getPackageCartInfo(string order_number)
        {
            ArrayList packages = new ArrayList();

            string sql = "select * from tb_package where order_number='" + order_number + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                PackageCartInfo package = new PackageCartInfo();
                package.Package_id = Convert.ToInt32(table.Rows[i]["package_id"].ToString());
               
                package.Description = table.Rows[i]["description"].ToString();
                package.Value = Convert.ToSingle(table.Rows[i]["package_value"].ToString());
                package.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                package.Length = Convert.ToSingle(table.Rows[i]["length"].ToString());
                package.Width = Convert.ToSingle(table.Rows[i]["width"].ToString());
                package.Height = Convert.ToSingle(table.Rows[i]["height"].ToString());

                packages.Add(package);
            }

            return packages;
        }
        //通过包裹编号获取包裹信息
        public Package getPackage(int package_id)
        {
            Package package = new Package();

            string sql = "select * from tb_package where package_id=" + package_id;

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {

                package.Package_id = Convert.ToInt32(table.Rows[i]["package_id"].ToString());
                package.Wp_track_no = table.Rows[i]["wp_track_no"].ToString();
                package.Order_number = table.Rows[i]["order_number"].ToString();
                package.Name = table.Rows[i]["name"].ToString();
                package.S_track_no = table.Rows[i]["s_track_no"].ToString();
                package.Cd_track_no = table.Rows[i]["cd_track_no"].ToString();
                package.Ea_track_no = table.Rows[i]["ea_track_no"].ToString();
                package.Local_track_no = table.Rows[i]["local_track_no"].ToString();
                package.Description = table.Rows[i]["description"].ToString();
                package.Package_value = Convert.ToSingle(table.Rows[i]["package_value"].ToString());
                package.Weight = Convert.ToSingle(table.Rows[i]["weight"].ToString());
                package.Length = Convert.ToSingle(table.Rows[i]["length"].ToString());
                package.Width = Convert.ToSingle(table.Rows[i]["width"].ToString());
                package.Height = Convert.ToSingle(table.Rows[i]["height"].ToString());
                package.Volumetric = Convert.ToSingle(table.Rows[i]["volumetric"].ToString());
                package.Chargeable = Convert.ToSingle(table.Rows[i]["chargeable"].ToString());
                package.Pay = Convert.ToSingle(table.Rows[i]["pay"].ToString());
                package.Insurance = Convert.ToSingle(table.Rows[i]["insurance"].ToString());
                package.Discount = Convert.ToSingle(table.Rows[i]["discount"].ToString());
                package.Departure = table.Rows[i]["departure"].ToString();
                package.Destination = table.Rows[i]["destination"].ToString();
                package.Post_way = table.Rows[i]["post_way"].ToString();
                package.True_weight = Convert.ToSingle(table.Rows[i]["true_weight"].ToString());
                package.True_length = Convert.ToSingle(table.Rows[i]["true_length"].ToString());
                package.True_width = Convert.ToSingle(table.Rows[i]["true_width"].ToString());
                package.True_height = Convert.ToSingle(table.Rows[i]["true_height"].ToString());
                package.True_volumetric = Convert.ToSingle(table.Rows[i]["true_volumetric"].ToString());
                package.True_chargeable = Convert.ToSingle(table.Rows[i]["true_chargeable"].ToString());
                package.True_pay = Convert.ToSingle(table.Rows[i]["true_pay"].ToString());
                package.Less_pay = Convert.ToSingle(table.Rows[i]["less_pay"].ToString());
                package.Is_pay = table.Rows[i]["is_pay"].ToString();
            }

            return package;
        }

        /// <summary>
        /// 通过订单号来获取同一订单包裹的总价值
        /// </summary>
        /// <param name="order_number"></param>
        /// <returns></returns>
        public float getSumMoney(string order_number)
        {
            float total = 0;

            string sql = "select sum(pay) from tb_package where order_number='" + order_number +"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                total = Convert.ToSingle(table.Rows[0][0]);
            }

            return total;
        }


        public float getSumWeight(string order_number)
        {
            float weight = 0;

            string sql = "select sum(weight) from tb_package where order_number='" + order_number + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                weight = Convert.ToSingle(table.Rows[0][0]);
            }

            return weight;

        }
        /// <summary>
        /// 跟新包裹的追踪号
        /// </summary>
        /// <param name="wp_track"></param>
        /// <param name="cd_track_no"></param>
        /// <param name="ea_track_no"></param>
        /// <param name="s_track_no"></param>
        /// <returns></returns>
        public bool updateTrackNo(string wp_track, string cd_track_no, string ea_track_no, string s_track_no)
        {
            bool flag = false;

            string sql = "update tb_package set cd_track_no='" + cd_track_no + "',ea_track_no='" + ea_track_no + "',s_track_no='" + s_track_no + "' where wp_track_no='" + wp_track + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }


        public bool updateLocalTrackNo(Package package)
        {
            bool flag = false;

            string sql = "update tb_package set local_track_no='" + package.Local_track_no + "' where package_id=" + package.Package_id;
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }
 
    }
}