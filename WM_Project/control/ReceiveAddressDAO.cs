using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using WM_Project.logical.user;

namespace WM_Project.control
{
    public class ReceiveAddressDAO
    {
        /// <summary>
        /// 通过会员名 name 获取该会员填写过的所有收件人地址
        /// </summary>
        /// <param name="name">通过会员名来查找数据库中的表</param>
        /// <returns>ArrayList对象 里面放置的是 ReceiverAddress类型对象</returns>
        public ArrayList getReceiveAddr(string name)
        {
            ArrayList arr = new ArrayList();

            SqlConnection conn = DBConn.getConn();
            string sql = "select * from tb_receiverAddress where name='" + name + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //一个会员可能多个收件人地址信息
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ReceiveAddress recAddr = new ReceiveAddress();
                recAddr.Addr_id = Convert.ToInt32(dt.Rows[i][0].ToString());
                recAddr.Name = dt.Rows[i][1].ToString();
                recAddr.Receiver_name = dt.Rows[i][2].ToString();
                recAddr.Country = dt.Rows[i][3].ToString();
                recAddr.Province = dt.Rows[i][4].ToString();
                recAddr.City = dt.Rows[i][5].ToString();
                recAddr.Area = dt.Rows[i][6].ToString();
                recAddr.Street_info = dt.Rows[i][7].ToString();
                recAddr.Company_name = dt.Rows[i][8].ToString();
                recAddr.Postcode = dt.Rows[i][9].ToString();
                recAddr.E_mail = dt.Rows[i][10].ToString();
                recAddr.Phone = dt.Rows[i][11].ToString();
                recAddr.Is_default = dt.Rows[i][12].ToString();

                recAddr.Time = Convert.ToDateTime(dt.Rows[i][13].ToString());

                arr.Add(recAddr);
            }

            return arr;
        }


        /// <summary>
        /// 通过会员名 name 获取该会员填写过的所有收件人地址
        /// </summary>
        /// <param name="name">通过会员名来查找数据库中的表</param>
        /// <returns>ArrayList对象 里面放置的是 ReceiverAddress类型对象</returns>
        public DataTable getReceiveTable(string name)
        {

            SqlConnection conn = DBConn.getConn();
            string sql = "select * from tb_receiverAddress where name='" + name + "' order by is_default desc , last_use_time desc";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }
        /// <summary>
        /// 向数据库中添加收件人地址
        /// </summary>
        /// <param name="receiver">收件人地址对象</param>
        /// <returns>添加成功返回true，否则返回false</returns>
        public bool addReceiverAddress(ReceiveAddress receive)
        {
            bool flag = false;
            SqlConnection conn = DBConn.getConn();

            string sql_insert = "insert into tb_receiverAddress values('" + receive.Name + "','" + receive.Receiver_name + "','" + receive.Country + "','" +
                           receive.Province + "','" + receive.City + "','" + receive.Area + "','" + receive.Street_info + "','" + receive.Company_name + "','" +
                           receive.Postcode + "','" + receive.Phone + "','" + receive.E_mail + "','" + receive.Is_default + "','" + receive.Time + "')";
            conn.Open();

            if (receive.Is_default == "1")
            {
                string sql_update = "update tb_receiverAddress set is_default='0' where name='" + receive.Name + "'";
                //跟新默认地址
                SqlCommand cmd1 = new SqlCommand(sql_update,conn);
                cmd1.ExecuteNonQuery();
            }
           
            
            SqlCommand cmd = new SqlCommand(sql_insert, conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        /// <summary>
        /// 修改收件人地址信息
        /// </summary>
        /// <param name="receiver">收件人地址对象</param>
        /// <returns>修改成功返回true ， 否则返回false</returns>
        public bool updateReceiveAddress(int addr_id, ReceiveAddress receive)
        {
            bool flag = false;
            SqlConnection conn = DBConn.getConn();
            string sql = "update tb_receiverAddress set receiver_name='" + receive.Receiver_name + "',country='" + receive.Country + "',province='" + receive.Province
                          + "',city='" + receive.City + "',area='" + receive.Area + "',street_info='" + receive.Street_info + "',company_name='" + receive.Company_name
                          + "',postcode='" + receive.Postcode + "',phone='" + receive.Phone + "',e_mail='" + receive.E_mail + "',is_default='" + receive.Is_default + "',last_use_time='"+receive.Time+ "' where addr_id=" + addr_id;
                          
            conn.Open();

            if (receive.Is_default == "1")
            {
                string sql_update = "update tb_receiverAddress set is_default='0' where name='" + receive.Name + "'";
                //跟新默认地址
                SqlCommand cmd1 = new SqlCommand(sql_update, conn);
                cmd1.ExecuteNonQuery();
            }

            SqlCommand cmd = new SqlCommand(sql, conn);

            if (cmd.ExecuteNonQuery() > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        /// <summary>
        /// 删除收件人地址
        /// </summary>
        /// <param name="addr_id">地址编号 addr_id</param>
        /// <returns>删除成功返回 true ,删除失败返回 false</returns>
        public bool deleteReceiveAddress(int addr_id)
        {
            bool flag = false;

            String sql = " delete from tb_receiverAddress where addr_id=" + addr_id ;
  
            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }
            return flag;
        }


        /// <summary>
        /// 通过地址编号获取地址信息
        /// </summary>
        /// <param name="addr_id">地址编号</param>
        /// <returns></returns>
        public ReceiveAddress getReceiveAddress(int addr_id)
        {
            ReceiveAddress recAddr = new ReceiveAddress();

            SqlConnection conn = DBConn.getConn();
            string sql = "select * from tb_receiverAddress where addr_id=" + addr_id ;
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //一个会员可能多个收件人地址信息
            if (dt.Rows.Count>0)
            {
                recAddr.Addr_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                recAddr.Name = dt.Rows[0][1].ToString();
                recAddr.Receiver_name = dt.Rows[0][2].ToString();
                recAddr.Country = dt.Rows[0][3].ToString();
                recAddr.Province = dt.Rows[0][4].ToString();
                recAddr.City = dt.Rows[0][5].ToString();
                recAddr.Area = dt.Rows[0][6].ToString();
                recAddr.Street_info = dt.Rows[0][7].ToString();
                recAddr.Company_name = dt.Rows[0][8].ToString();
                recAddr.Postcode = dt.Rows[0][9].ToString();
                recAddr.E_mail = dt.Rows[0][10].ToString();
                recAddr.Phone = dt.Rows[0][11].ToString();
                recAddr.Is_default = dt.Rows[0][12].ToString();

                recAddr.Time = Convert.ToDateTime(dt.Rows[0][13].ToString());
            }
            return recAddr;
        }

        /// <summary>
        /// 通过收件地址编号获得收件地址信息
        /// </summary>
        /// <param name="addr_id">收件地址编号</param>
        /// <returns></returns>
        public string getAddressInfo(int addr_id)
        {
            string address = "";

            ReceiveAddress receive = getReceiveAddress(addr_id);

            address = receive.Country + receive.Province + receive.City + receive.Area + receive.Street_info + receive.Company_name;
            address += receive.Postcode + "," + receive.Phone + "(" + receive.Receiver_name + "收)";

            return address;
        }


        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="addr_id">地址编号</param>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        public bool setDefault(int addr_id,string name)
        {
            bool flag=false;

            string sql = "update tb_receiverAddress set is_default='0' where name='" + name + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                string sql1 = "update tb_receiverAddress set is_default='1' where addr_id=" + addr_id;

                if (new DBOperateCommon().excuteNoQuery(sql1))
                {
                    flag = true;
                }
            }

            return flag;
        }
    }
}