using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.user;


namespace WM_Project.control
{
    public class MyAccountTransDAO
    {
        /// <summary>
        /// 向我的账户交易记录表中添加交易记录
        /// </summary>
        /// <param name="myaccounttrans">账户交易对象</param>
        /// <returns>添加成功返回 true，否则返回 false</returns>
        public bool addMyAccountTrans(MyAccountTrans myaccounttrans)
        {
            bool flag = false;

            string sql = "insert into tb_my_account_trans values('" + myaccounttrans.User_name + "'," + myaccounttrans.Amout + ",'" + myaccounttrans.Operation + "'," + myaccounttrans.Ratio + ",'" + myaccounttrans.Charge_way + "','" + myaccounttrans.Bank_account_number + "','" + myaccounttrans.Order_number + "','" + myaccounttrans.Time.ToString() + "')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 通过用户名获取用户的账户交易记录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>记录条数</returns>
        public int getMyAccountTransCount(string name)
        {
            int count = 0;

            string sql = "select count(*) from tb_my_account_trans where user_name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0]);
            }

            return count;

        }

        /// <summary>
        /// 分页获取交易记录
        /// </summary>
        /// <param name="pageNow">当前页数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public ArrayList getMyAccountTrans(int pageNow, int pageSize,string name)
        {
            ArrayList trans = new ArrayList();

            string sql = "select top " + pageSize + " * from tb_my_account_trans where user_name='" + name + "' and id not in(select top " + (pageNow - 1) * pageSize + " id from tb_my_account_trans where user_name='" + name + "' order by trans_time desc ) order by trans_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count;i++ )
            {
                MyAccountTrans myaccounttans = new MyAccountTrans();
                myaccounttans.User_name = table.Rows[i]["user_name"].ToString();
                myaccounttans.Amout = Convert.ToSingle(table.Rows[i]["amount"].ToString());
                myaccounttans.Operation = table.Rows[i]["operation"].ToString();
                myaccounttans.Ratio = Convert.ToSingle(table.Rows[i]["ratio"].ToString());
                myaccounttans.Charge_way = table.Rows[i]["charge_way"].ToString();
                myaccounttans.Bank_account_number = table.Rows[i]["bank_account_number"].ToString();
                myaccounttans.Order_number = table.Rows[i]["order_number"].ToString();
                myaccounttans.Time = Convert.ToDateTime(table.Rows[i]["trans_time"].ToString());

                trans.Add(myaccounttans);
            }

            return trans;
        }

        /// <summary>
        /// 获取页数
        /// </summary>
        /// <returns></returns>
        public int getPageCount(int recordcount,int pagesize)
        {
            int pagecount = 0;

            if (recordcount % pagesize == 0)
            {
                pagecount = recordcount / pagesize;
            }
            else
            {
                pagecount = recordcount / pagesize + 1;
            }

            return pagecount;
        }

        //////////////////////////////////////////////////////////////////////////
        //获得卡充值的记录
        public DataTable getCardChargeRecordTable(int is_checked, int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            string sql = "select top " + pageSize + " * from tb_my_account_trans where operation='自己给账户充值' and ratio=" + is_checked + " and id not in(select top " + (pageNow - 1) * pageSize + " id from tb_my_account_trans where operation='自己给账户充值' and ratio=" + is_checked + " order by trans_time desc ) order by trans_time";

            table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }

        public int getCardChargeCount(int is_checked)
        {
            int count = 0;

            string sql = "select count(*) from tb_my_account_trans where operation='自己给账户充值' and ratio=" + is_checked;
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;

        }

        public bool checkCardCharge(int id)
        {
            bool flag = false;

            string sql = "update tb_my_account_trans set ratio=1 where id=" + id;

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }
    }
}