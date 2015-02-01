using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.control
{
    public class SetEMSRateForUserDAO
    {


        public UserRate getUserRate(string name)
        {
            UserRate user_rate = null;
            string sql = "select * from tb_set_user_ems_rate where username='" + name + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                user_rate = new UserRate();
                user_rate.Name = table.Rows[0]["username"].ToString();
                user_rate.Ratetype = table.Rows[0]["ratetype"].ToString();
            }
            return user_rate;
        }

        /// <summary>
        /// 更新用户的EMS邮费类型
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="ratetype">邮费类别</param>
        /// <param name="admin">管理员</param>
        /// <returns>1 表示更新成功， 2 表示更新失败 ， 3 表示 设置成功，4 表示设置失败</returns>
        public int setRateForUser(string username,string ratetype,string admin)
        {
            int flag = -1;
            string sql = "select * from tb_set_user_ems_rate where username='" + username + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                //更新用户的邮费类别
                string up_sql = "update tb_set_user_ems_rate set ratetype='" + ratetype + "' , setername='" + admin + "' , settime='" + DateTime.Now.ToString() + "'";
                if (new DBOperateCommon().excuteNoQuery(up_sql))
                {
                    flag = 1;
                }
                else
                {
                    flag = 2;
                }
            }
            else
            {
                string insert_sql = "insert into tb_set_user_ems_rate values('" + username + "','" + ratetype + "','" + admin + "','" + DateTime.Now.ToString() + "')";

                if (new DBOperateCommon().excuteNoQuery(insert_sql))
                {
                    flag = 3;
                }
                else
                {
                    flag = 4;
                }
            }
            return flag;
        }

        /// <summary>
        /// 删除用户优惠
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool deleteUserRate(string username)
        {
            bool flag = false;

            string sql = "delete from tb_set_user_ems_rate where username='" + username + "'";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 获取用户的邮费信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserRate(int pageNow, int pageSize)
        {
            DataTable table = new DataTable();
            string sql = "select top " + pageSize + " * from tb_set_user_ems_rate where username not in(select top " + (pageNow - 1) * pageSize + " username from tb_set_user_ems_rate)";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }

        /// <summary>
        /// 获取用户邮费记录条数
        /// </summary>
        /// <returns></returns>
        public int getUserRateCount()
        {
            int count = 0;
            string sql = "select count(*) from tb_set_user_ems_rate";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0]);
            }
            return count;
        }


        /// <summary>
        /// 计算页数
        /// </summary>
        /// <param name="recordCount">记录的条数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public int getPageCount(int recordCount, int pageSize)
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