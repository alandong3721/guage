using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;
using WM_Project.logical.user;

namespace WM_Project.control
{
    public class SetPFIPEPolRateForUserDAO
    {
        /// <summary>
        /// 获取用户 邮费类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserRate getUserRate(string name)
        {
            UserRate user_rate = null;
            string sql = "select * from tb_set_user_pf_ipe_pol_rate where username='" + name + "'";
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
        /// 更新或者设置用户的邮费类型
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="ratetype">类型</param>
        /// <param name="setername">设置者</param>
        /// <returns>跟新成功返回 1，失败返回 2； 设置成功返回 3，失败返回 4</returns>
        public int setRateForUser(string username, string ratetype, string setername)
        {
            int flag = 0;

            string str = "select * from tb_set_user_pf_ipe_pol_rate where username='" + username + "'";

            DataTable table = new DBOperateCommon().excuteQuery(str);

            if (table.Rows.Count > 0)
            {
                //该用户已经存在，即为更新操作
                string sql = "update tb_set_user_pf_ipe_pol_rate set ratetype='" + ratetype + "',setername='" + setername + "',settime='" + DateTime.Now.ToString() + "' where username='" + username + "'";

                if (new DBOperateCommon().excuteNoQuery(sql))
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
                string sql = "insert into tb_set_user_pf_ipe_pol_rate values('" + username + "','" + ratetype + "','" + setername + "','" + DateTime.Now.ToString() + "')";

                if (new DBOperateCommon().excuteNoQuery(sql))
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

            string sql = "delete from tb_set_user_pf_ipe_pol_rate where username='" + username + "'";
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
            string sql = "select top " + pageSize + " * from tb_set_user_pf_ipe_pol_rate where username not in(select top " + (pageNow - 1) * pageSize + " username from tb_set_user_pf_ipe_pol_rate)";
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
            string sql = "select count(*) from tb_set_user_pf_ipe_pol_rate";
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