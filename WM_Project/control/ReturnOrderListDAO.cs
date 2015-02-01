using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WM_Project.logical.common;


namespace WM_Project.control
{
    public class ReturnOrderListDAO
    {
        //public ArrayList getReturnOrderList(int pageNow,int pageSize)
        //{
        //    ArrayList array = new ArrayList();
        //    string sql = "select top " + pageSize + "  name,order_no,pay_after_discount from tb_auto_orderlist where pay_status='paied' and is_return=1 and order_no not in(select top" + (pageNow - 1) * pageSize + " order_no from tb_auto_orderlist where pay_status='paied' and is_return=1 )";
        //    DataTable table = new DBOperateCommon().excuteQuery(sql);

        //    for (int i = 0; i < table.Rows.Count;i++ )
        //    {
        //        ReturnOrderList orderlist = new ReturnOrderList();
        //        orderlist.Name = table.Rows[i]["name"].ToString();
        //        orderlist.Order_number = table.Rows[i]["order_no"].ToString();
        //        orderlist.Money = Convert.ToSingle(table.Rows[i]["pay_after_discount"].ToString());
        //        array.Add(orderlist);
        //    }

        //    return array;

        //}



        //public int getReturnOrderListCount()
        //{
        //    int count = 0;

        //    string sql = "select count(*) from tb_auto_orderlist where pay_status='paied' and is_return=1";
        //    DataTable table = new DBOperateCommon().excuteQuery(sql);
        //    if (table.Rows.Count > 0)
        //    {
        //        count = Convert.ToInt32(table.Rows[0][0].ToString());
        //    }

        //    return count;
        //}

        public int getPageCount(int record,int pageSize)
        {
            int pagecount = 0;

            if (record % pageSize == 0)
            {
                pagecount = record / pageSize;
            }
            else
            {
                pagecount = record / pageSize + 1;
            }

            return pagecount;
        }
    }
}