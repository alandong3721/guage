using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.logical.user;

namespace WM_Project.control
{
    public class AddressDAO
    {

        /// <summary>
        /// 向地址簿中添加地址信息
        /// </summary>
        /// <param name="address">地址对象</param>
        /// <returns></returns>
        public bool addAddress(Address address)
        {
            bool flag = false;

            if (address.Is_default == "1")
            {
                string setdefault = "update tb_addr_book set is_default='0' where user_name='" + address.User_name + "'";
                new DBOperateCommon().excuteNoQuery(setdefault);
            }

            string sql = "insert into tb_addr_book values('"+address.User_name+"','"+address.Company_name+"','"+address.Addr_type+"','"+address.Addr_contact+"','"+
                address.Addr_line1+"','"+address.Addr_line2+"','"+address.Addr_line3+"','"+address.City+"','"+address.Post_code+"','"+address.Country+"','"+address.Phone+"','"+
                address.Email + "','" + address.Is_default + "','" + address.Time + "')";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;

        }

        
        /// <summary>
        /// 更新地址簿中的地址信息
        /// </summary>
        /// <param name="address">新的地址对象</param>
        /// <returns>更新成功返回 true ， 更新失败返回 false</returns>
        public bool updateAddress(Address address)
        {
            bool flag = false;

            if (address.Is_default == "1")
            {
                string setdefault = "update tb_addr_book set is_default='0' where user_name='" + address.User_name + "'";
                new DBOperateCommon().excuteNoQuery(setdefault);
            }

            string update = "update tb_addr_book set user_name='"+address.User_name+"',company_name='"+address.Company_name+"',addr_type='"+address.Addr_type+"',addr_contact='"+address.Addr_contact+"',addr_line1='"+
                address.Addr_line1+"',addr_line2='"+address.Addr_line2+"',addr_line3='"+address.Addr_line3+"',city='"+address.City+"',post_code='"+address.Post_code+"',country='"+address.Country+"',phone='"+address.Phone+"',email='"+
                address.Email + "',is_default='" + address.Is_default + "',time='" + address.Time + "' where addr_id="+address.Addr_id ;

            if (new DBOperateCommon().excuteNoQuery(update))
            {
                flag = true;

            }

            return flag;
        }


        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="addr_id">地址编号</param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool setDefaultAddress(int addr_id,string name)
        {
            bool flag = false;
            
            string setdefault = "update tb_addr_book set is_default='0' where user_name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(setdefault))
            {
                string update = "update tb_addr_book set is_default='1' where addr_id=" + addr_id;
                if (new DBOperateCommon().excuteNoQuery(update))
                {
                    flag = true;
                }
            }

            return flag;

        }


        /// <summary>
        /// 通过地址编号从地址簿中删除地址
        /// </summary>
        /// <param name="addr_id">地址编号</param>
        /// <returns>如果删除成功返回 true 、 否则返回 false</returns>
        public bool deleteAddress(int addr_id)
        {
            bool flag = false;

            string delete = "delete from tb_addr_book where addr_id=" + addr_id;

            if(new DBOperateCommon().excuteNoQuery(delete))
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 通过addr_id获取地址信息
        /// </summary>
        /// <param name="addr_id"></param>
        /// <returns></returns>
        public Address getAddress(int addr_id)
        {
            Address address = new Address();

            string sql = "select * from tb_addr_book where addr_id=" + addr_id;

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                address.Addr_id = addr_id;
                address.User_name = table.Rows[0]["user_name"].ToString();
                address.Company_name = table.Rows[0]["company_name"].ToString();
                address.Addr_type = table.Rows[0]["addr_type"].ToString();
                address.Addr_contact = table.Rows[0]["addr_contact"].ToString();
                address.Addr_line1 = table.Rows[0]["addr_line1"].ToString();
                address.Addr_line2 = table.Rows[0]["addr_line2"].ToString();
                address.Addr_line3 = table.Rows[0]["addr_line3"].ToString();
                address.City = table.Rows[0]["city"].ToString();
                address.Post_code = table.Rows[0]["post_code"].ToString();
                address.Country = table.Rows[0]["country"].ToString();
                address.Phone = table.Rows[0]["phone"].ToString();
                address.Email = table.Rows[0]["email"].ToString();
                address.Is_default = table.Rows[0]["is_default"].ToString();
                
            }
            return address;
        }


        /// <summary>
        /// 通过用户名获取地址信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public ArrayList getAddress(string user_name)
        {
            ArrayList address_array = new ArrayList();

            string sql = "select * from tb_addr_book where user_name='" + user_name + "' order by is_default desc,time desc";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Address address = new Address();

                address.Addr_id = Convert.ToInt32(table.Rows[i]["addr_id"]);
                address.User_name = table.Rows[i]["user_name"].ToString();
                address.Company_name = table.Rows[i]["company_name"].ToString();
                address.Addr_type = table.Rows[i]["addr_type"].ToString();
                address.Addr_contact = table.Rows[i]["addr_contact"].ToString();
                address.Addr_line1 = table.Rows[i]["addr_line1"].ToString();
                address.Addr_line2 = table.Rows[i]["addr_line2"].ToString();
                address.Addr_line3 = table.Rows[i]["addr_line3"].ToString();
                address.City = table.Rows[i]["city"].ToString();
                address.Post_code = table.Rows[i]["post_code"].ToString();
                address.Country = table.Rows[i]["country"].ToString();
                address.Phone = table.Rows[i]["phone"].ToString();
                address.Email = table.Rows[i]["email"].ToString();
                address.Is_default = table.Rows[i]["is_default"].ToString();
                
                address_array.Add(address);
            }

            return address_array;
        }


        /// <summary>
        /// 通过会员名获取地址信息表
        /// </summary>
        /// <param name="user_name">会员名</param>
        /// <returns></returns>
        public DataTable getAddressTable(string user_name)
        {
            DataTable table = new DataTable();
            string sql = "select * from tb_addr_book where user_name='" + user_name + "' order by is_default desc, time desc";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }


        /// <summary>
        /// 发件地址表
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public DataTable getSendAddressTable(string user_name)
        {
            DataTable table = new DataTable();
            string sql = "select * from tb_addr_book where user_name='" + user_name + "' and addr_type='S' order by is_default desc, time desc";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }


        /// <summary>
        /// 获取收件地址表
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public DataTable getReceiveAddressTable(string user_name)
        {
            DataTable table = new DataTable();
            string sql = "select * from tb_addr_book where user_name='" + user_name + "' and addr_type='R' order by is_default desc, time desc";
            table = new DBOperateCommon().excuteQuery(sql);
            return table;
        }

        /// <summary>
        /// 获取地址信息
        /// </summary>
        /// <param name="addr_id"></param>
        /// <returns></returns>
        public string getAddressInfo(int addr_id)
        {
            string address_info = "";
            Address address = getAddress(addr_id);
            address_info+=address.Addr_line1+address.Addr_line2+address.Addr_line3+address.City+address.Country;
            return address_info;
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //地址分页实现

        /// <summary>
        /// 获取发件地址的条数
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>返回记录的条数</returns>
        public int getSendAddressCount(string name)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_addr_book where user_name='" + name + "' and addr_type='S'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0].ToString());
            }

            return recordCount;
        }

        /// <summary>
        /// 分页获取发件地址信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public DataTable getSendAddressTable(string name, int pageNow, int pageSize)
        {
            DataTable table = new DataTable();

            string sql = "select top "+pageSize+" * from tb_addr_book where user_name='"+name+"' and addr_type='S' and addr_id not in (select top "+(pageNow-1)*pageSize+" addr_id from tb_addr_book where user_name='"
                + name + "' and addr_type='S') order by is_default desc, time desc";

            table = new DBOperateCommon().excuteQuery(sql);

            return table;

        }

        /// <summary>
        /// 分页获取收件地址信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pageNow">当前页</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public DataTable getReceiveAddressTable(string name,int pageNow,int pageSize)
        {
            DataTable table = new DataTable();

            string sql = "select top " + pageSize + " * from tb_addr_book where user_name='" + name + "' and addr_type='R' and addr_id not in (select top " + (pageNow - 1) * pageSize + " addr_id from tb_addr_book where user_name='"
                + name + "' and addr_type='R') order by is_default desc, time desc";

            table = new DBOperateCommon().excuteQuery(sql);

            return table;
        }


        /// <summary>
        /// 获取收件地址的条数
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>返回记录的条数</returns>
        public int getReceiveAddressCount(string name)
        {
            int recordCount = 0;

            string sql = "select count(*) from tb_addr_book where user_name ='" + name + "' and addr_type='R'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0)
            {
                recordCount = Convert.ToInt32(table.Rows[0][0]);
            }

            return recordCount;
        }

        /// <summary>
        /// 获取显示地址所需的页面
        /// </summary>
        /// <param name="recordCount">记录条数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public int getAddresPageCount(int recordCount,int pageSize)
        {
            int pageCount = 0;

            if(recordCount%pageSize==0)
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