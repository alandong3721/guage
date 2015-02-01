using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.user;

namespace WM_Project.control
{
    public class UserDebtDAO
    {

        /// <summary>
        /// 获取用户的欠款对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserDebt getUserDebt(string name)
        {
            UserDebt userdebt = null;

            string sql = "select * from tb_user_debt where user_name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                userdebt = new UserDebt();
                userdebt.Amount = Convert.ToSingle(table.Rows[0]["amount"].ToString());
                userdebt.User_name = name;
            }

            return userdebt;
        }

        // 跟新用户的 欠款表
        public bool updateUserDebt(UserDebt userdebt)
        {
            bool flag = false;

            string str = "select * from tb_user_debt where user_name='" +userdebt.User_name+ "'";

            DataTable table = new DBOperateCommon().excuteQuery(str);
            
            if (table.Rows.Count > 0)
            {
                // 该用户不是第一次借款
                float old_amount = Convert.ToSingle(table.Rows[0]["amount"].ToString());
                float new_amount = old_amount + userdebt.Amount;

                string up = "update tb_user_debt set amount=" + new_amount + " where user_name='" + userdebt.User_name + "'";
                if (new DBOperateCommon().excuteNoQuery(up))
                {
                    flag = true;
                }
            }
            else
            {
                string sql = "insert into tb_user_debt values('" + userdebt.User_name + "'," + userdebt.Amount + ")";
                if (new DBOperateCommon().excuteNoQuery(sql))
                {
                    flag = true;
                }
            }

            return flag;
        }


        /// <summary>
        /// 分页获欠款用户
        /// </summary>
        /// <param name="pageNow"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ArrayList getUserDebts(int pageNow,int pageSize)
        {
            ArrayList userdebts = new ArrayList();

            string sql = "select top "+pageSize+" * from tb_user_debt where user_name not in(select top "+(pageNow-1)*pageSize+" user_name from tb_user_debt order by amount desc) order by amount desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                UserDebt userdebt = new UserDebt();
                userdebt.User_name = table.Rows[i]["user_name"].ToString();
                userdebt.Amount = Convert.ToSingle(table.Rows[i]["amount"]);

                userdebts.Add(userdebt);
            }

            return userdebts;

        }


        /// <summary>
        /// 获取欠款的人数
        /// </summary>
        /// <returns>返回欠款人数</returns>
        public int getUserDebtCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_user_debt";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }


            return count;
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns>返回页数</returns>
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
    }
}