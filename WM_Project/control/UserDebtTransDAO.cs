using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.user;
using WM_Project.control;

namespace WM_Project.control
{
    public class UserDebtTransDAO
    {
        //添加欠款交易记录
        public bool addUserDebtTrans(UserDebtTrans userdebttrans)
        {
            bool flag = false;

            string sql = "insert into tb_user_debt_trans values('" + userdebttrans.User_name + "'," + userdebttrans.Amount + ",'" + userdebttrans.Operation + "','" + userdebttrans.Operation_time.ToString() + "','"+userdebttrans.Note+"')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 获取给定用户的欠款交易信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public ArrayList getUserDebtTransInfo(string name)
        {
            ArrayList debtTransInfo = new ArrayList();

            string sql = "select  * from tb_user_debt_trans where user_name='"+name+"' order by operation_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                UserDebtTrans usertrans = new UserDebtTrans();
                usertrans.Id = Convert.ToInt32(table.Rows[i]["id"].ToString());
                usertrans.User_name = table.Rows[i]["user_name"].ToString();
                usertrans.Amount = Convert.ToSingle(table.Rows[i]["amount"].ToString());
                usertrans.Operation = table.Rows[i]["operation"].ToString();
                usertrans.Operation_time = Convert.ToDateTime(table.Rows[i]["operation_time"].ToString());
                usertrans.Note = table.Rows[i]["note"].ToString();
                debtTransInfo.Add(usertrans);
            }

            return debtTransInfo;
        }

        /// <summary>
        /// 分页获取交易记录
        /// </summary>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public ArrayList getChargeRecords(int pageNow,int pageSize)
        {
            ArrayList record_array = new ArrayList();

            string sql ="select top "+pageSize+" * from tb_user_debt_trans where  id not in(select top "+(pageNow-1)*pageSize+" id from tb_user_debt_trans  order by operation_time desc) order by operation_time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                UserDebtTrans usertrans = new UserDebtTrans();
                usertrans.Id = Convert.ToInt32(table.Rows[i]["id"].ToString());
                usertrans.User_name = table.Rows[i]["user_name"].ToString();
                usertrans.Amount = Convert.ToSingle(table.Rows[i]["amount"].ToString());
                usertrans.Operation = table.Rows[i]["operation"].ToString();
                usertrans.Operation_time = Convert.ToDateTime(table.Rows[i]["operation_time"].ToString());
                usertrans.Note = table.Rows[i]["note"].ToString();
                record_array.Add(usertrans);
            }

           return record_array;
        }

        //获取交易记录条数
        public int getRecordCount()
        {
            int record_count = 0;
            string sql = "select count(*) from tb_user_debt_trans ";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count>0)
            {
                record_count = Convert.ToInt32(table.Rows[0][0].ToString());
            }
            return record_count;
        }


        /// <summary>
        /// 获取页数
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public int getPageCount(int pageSize,int recordCount)
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