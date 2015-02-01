using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;
using WM_Project.logical.user;
using System.Collections;


namespace WM_Project.control
{
    public class MyAccountDAO
    {

        /// <summary>
        /// 通过账户名获取账户信息
        /// </summary>
        /// <param name="name">账户名</param>
        /// <returns></returns>
        public MyAccount getMyAccount(string name)
        {
            MyAccount myaccount = null;

            string sql = "select * from tb_my_account where name='" + name + "'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            if (table.Rows.Count > 0)
            {
                myaccount = new MyAccount();
                myaccount.Name = table.Rows[0]["name"].ToString();
                myaccount.Balance = Convert.ToSingle(table.Rows[0]["balance"].ToString());
            }

            return myaccount;
        }

        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// <param name="myaccount"></param>
        /// <returns></returns>
        public bool addMyAccount(MyAccount myaccount)
        {
            bool flag = false;

            string sql = "insert into tb_my_account values('" + myaccount.Name + "'," + myaccount.Balance + ",0,0,0,0,'',0,0)";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 为用户充值
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="money">充值金额</param>
        /// <returns>充值成功返回 true,否则返回 false</returns>
        public bool chargeForUser(string account,float money)
        {
            bool flag = false;

            string sql = "select * from tb_my_account where name='" + account + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            //说明
            if (table.Rows.Count > 0)
            {
                float old_balance = Convert.ToSingle(table.Rows[0]["balance"].ToString());

                float new_balance = old_balance + money;

                string update = "update tb_my_account set balance=" + new_balance + " where name='" + account + "'";

                if (new DBOperateCommon().excuteNoQuery(update))
                {
                    flag = true;

                    //添加成功时向账户交易记录表中添加交易记录
                    MyAccountTrans myaccounttrans = new MyAccountTrans();
                    myaccounttrans.User_name = account;
                    myaccounttrans.Amout = money;
                    myaccounttrans.Charge_way = "ukchinesecentre-account";
                    myaccounttrans.Operation = "森林运输为客户预充值";
                    myaccounttrans.Time = DateTime.Now;
                    new MyAccountTransDAO().addMyAccountTrans(myaccounttrans);

                    // 跟新用户的 欠款表
                    UserDebt userdebt = new UserDebt();
                    userdebt.User_name = account;
                    userdebt.Amount = money;
                    new UserDebtDAO().updateUserDebt(userdebt);
                    //添加 欠款交易信息
                    UserDebtTrans userdebttrans = new UserDebtTrans();
                    userdebttrans.Amount = money;
                    userdebttrans.User_name = account;
                    userdebttrans.Operation = "借款";
                    userdebttrans.Operation_time = DateTime.Now;
                    new UserDebtTransDAO().addUserDebtTrans(userdebttrans);

                }

            }
            else
            {
                string insert = "insert into tb_my_account values('" + account + "'," + money + ",0,0,0,0,'',0,0)";
                if (new DBOperateCommon().excuteNoQuery(insert))
                {
                    flag = true;
                    //添加成功时向账户交易记录表中添加交易记录
                    MyAccountTrans myaccounttrans = new MyAccountTrans();
                    myaccounttrans.User_name = account;
                    myaccounttrans.Amout = money;
                    myaccounttrans.Charge_way = "ukchinesecentre-account";
                    myaccounttrans.Operation = "森林运输为客户预充值";
                    myaccounttrans.Time = DateTime.Now;
                    new MyAccountTransDAO().addMyAccountTrans(myaccounttrans);

                    // 跟新用户的 欠款表
                    UserDebt userdebt = new UserDebt();
                    userdebt.User_name = account;
                    userdebt.Amount = money;
                    new UserDebtDAO().updateUserDebt(userdebt);

                    //添加 欠款交易信息
                    UserDebtTrans userdebttrans = new UserDebtTrans();
                    userdebttrans.Amount = money;
                    userdebttrans.User_name = account;
                    userdebttrans.Operation = "借款";
                    userdebttrans.Operation_time = DateTime.Now;
                    new UserDebtTransDAO().addUserDebtTrans(userdebttrans);
                }
            }

            return flag;
        }

        /// <summary>
        /// 用户使用账户付款
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="money">付款金额</param>
        /// <returns></returns>
        public bool userPayUseMyAccount(string account,float money)
        {
            bool flag = false;

            string sql = "select * from tb_my_account where name='" + account + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            float old_balance = Convert.ToSingle(table.Rows[0]["balance"].ToString());
            float new_balance = old_balance - money;
            // 跟新账户表
            string update = "update tb_my_account set balance=" + new_balance + " where name='" + account + "'";
            
            if (new DBOperateCommon().excuteNoQuery(update))
            {
                // 付款成功
                flag = true;

                // 向账户交易记录表中添加交易记录
                MyAccountTrans myaccounttrans = new MyAccountTrans();
                myaccounttrans.Amout = -money;
                myaccounttrans.Operation = "下单付款";
                myaccounttrans.User_name = account;
                myaccounttrans.Time = DateTime.Now;

                new MyAccountTransDAO().addMyAccountTrans(myaccounttrans);

            }

            return flag;
        }

        /// <summary>
        /// 跟新用户的账户表
        /// </summary>
        /// <param name="account"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public bool updateMyAccount(string account, float balance)
        {
            bool flag = false;

            string sql = "update tb_my_account set balance=" + balance + " where name='" + account + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = false;
            }

            return flag;

        }

        //////////////////////////////////////////////////////////////////////////
        //账户余额管理部分

        /// <summary>
        /// 分页获取账户余额信息
        /// </summary>
        /// <param name="page_now"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public ArrayList getMyAccountArray(int page_now, int page_size)
        {
            ArrayList array = new ArrayList();

            string sql = "select top " + page_size + " * from tb_my_account where name not in(select top " + (page_now - 1) * page_size + " name from tb_my_account order by balance desc) order by balance desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                MyAccount my_account = new MyAccount();
                my_account.Name = table.Rows[i]["name"].ToString();
                my_account.Balance = Convert.ToSingle(table.Rows[i]["balance"].ToString());

                array.Add(my_account);

            }

            return array;
        }
        public int getMyAccountCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_my_account";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }

        public int getMyAccountPageCount(int record_count, int page_size)
        {
            int page_count = 0;

            if (record_count % page_size == 0)
            {
                page_count = record_count / page_size;
            }
            else
            {
                page_count = record_count / page_size + 1;
            }

            return page_count;
        }
    }
}