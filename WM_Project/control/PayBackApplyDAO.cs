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
    public class PayBackApplyDAO
    {

        /// <summary>
        /// 添加还款申请
        /// </summary>
        /// <param name="payback"></param>
        /// <returns></returns>
        public bool addPayBackApply(PayBackApply payback)
        {
            bool flag = false;

            string sql = "insert into tb_payback_apply values('" + payback.User_name + "'," + payback.Amount + ",'" + payback.Operation + "','" + payback.Staff_apply + "','" + payback.Operation_time.ToString() + "','" + payback.Note + "','" + payback.Image + "'," + payback.Is_aggree + ")";
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 通过编号获取 待审核的还款信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PayBackApply getPayBackApply(int id)
        {
            PayBackApply payback = new PayBackApply();
            string sql = "select * from tb_payback_apply where id=" + id;
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            if (table.Rows.Count > 0)
            {
                payback.Id = Convert.ToInt32(table.Rows[0]["id"].ToString());
                payback.User_name = table.Rows[0]["user_name"].ToString();
                payback.Amount = Convert.ToSingle(table.Rows[0]["amount"].ToString());
                payback.Staff_apply = table.Rows[0]["staff_apply"].ToString();
                payback.Operation = table.Rows[0]["operation"].ToString();
                payback.Operation_time = Convert.ToDateTime(table.Rows[0]["operation_time"].ToString());
                payback.Note = table.Rows[0]["note"].ToString();
                payback.Image = table.Rows[0]["image"].ToString();
                payback.Is_aggree = Convert.ToInt32(table.Rows[0]["is_agree"].ToString());

            }

            return payback;

        }

        /// <summary>
        /// is_agree = 0 表示申请 还款
        /// </summary>
        /// <returns></returns>
        public DataTable getPayBackApplyTable(int pageNow,int pageSize)
        {
            DataTable table = new DataTable();
            string sql = "select top "+pageSize+" * from tb_payback_apply where is_agree=0 and id not in(select top "+(pageNow-1)*pageSize+" id from tb_payback_apply where is_agree=0)";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }

        /// <summary>
        /// 分页获取未通过
        /// </summary>
        /// <param name="pageNow"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable getUnPassPayBackApplyTable(int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            string sql = "select top " + pageSize + " * from tb_payback_apply where is_agree=2 and id not in(select top " + (pageNow - 1) * pageSize + " id from tb_payback_apply where is_agree=2)";
            table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }
        /// <summary>
        /// 获取申请还款的 列表
        /// </summary>
        /// <returns></returns>
        public ArrayList getPayBackApplyArray()
        {
            ArrayList array = new ArrayList();

            string sql = "select * from tb_payback_apply where is_agree=0";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PayBackApply payback = new PayBackApply();
                payback.Id = Convert.ToInt32(table.Rows[i]["id"].ToString());
                payback.User_name = table.Rows[i]["user_name"].ToString();
                payback.Amount = Convert.ToSingle(table.Rows[i]["amount"].ToString());
                payback.Staff_apply = table.Rows[i]["apply_staff"].ToString();
                payback.Operation = table.Rows[i]["operation"].ToString();
                payback.Operation_time = Convert.ToDateTime(table.Rows[i]["operation_time"].ToString());
                payback.Note = table.Rows[i]["note"].ToString();
                payback.Image = table.Rows[i]["image"].ToString();
                payback.Is_aggree = Convert.ToInt32(table.Rows[i]["is_agree"].ToString());

                array.Add(payback);
            }

            return array;
        }


        /// <summary>
        /// 获取申请还款的条数
        /// </summary>
        /// <returns></returns>
        public int getPayBackApplyCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_payback_apply where is_agree=0";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }

        /// <summary>
        /// 获取申请还款的条数
        /// </summary>
        /// <returns></returns>
        public int getUnPassPayBackApplyCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_payback_apply where is_agree=2";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                count = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return count;
        }
        /// <summary>
        /// 获取申请还款的纪录的页数
        /// </summary>
        /// <param name="recordcount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int getPayBackApplyPageCount(int recordcount, int pageSize)
        {
            int page_count = 0;
            if (recordcount % pageSize ==0)
            {
                page_count = recordcount / pageSize;
            }
            else
            {
                page_count = recordcount / pageSize + 1;
            }

            return page_count;
        }

        


        /// <summary>
        /// 同意返款  将 id 置为 1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool agreePayBack(int id)
        {
            bool flag = false;

            string sql ="update tb_payback_apply set is_agree=1 where id="+id;

            if(new DBOperateCommon().excuteNoQuery(sql)){
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 不同意返款 将 id 置为 2
        /// </summary>
        /// <returns></returns>
        public bool unAgreePayBack(int id)
        {
            bool flag = false;

            string sql = "update tb_payback_apply set is_agree=2 where id=" + id;
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }
    }
}