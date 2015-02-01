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
    public class SendAddressDAO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">通过会员名来查找数据库中的表</param>
        /// <returns>ArrayList对象 里面放置的是 SendAddress类型对象</returns>
        public ArrayList getSenderAddr(string name)
        {
            ArrayList arr = new ArrayList();

            SqlConnection conn = DBConn.getConn();
            string sql = "select * from tb_senderAddress where name='" + name + "' order by is_default desc,last_use_time desc";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            //一个会员可能有多个发件人地址
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SendAddress sendAddr = new SendAddress();
                sendAddr.Addr_id = Convert.ToInt32(dt.Rows[i][0].ToString());
                sendAddr.Name = dt.Rows[i][1].ToString();
                sendAddr.Sender_name = dt.Rows[i][2].ToString();
                sendAddr.Country = dt.Rows[i][3].ToString();
                sendAddr.Province = dt.Rows[i][4].ToString();
                sendAddr.City = dt.Rows[i][5].ToString();
                sendAddr.Area = dt.Rows[i][6].ToString();
                sendAddr.Street_info = dt.Rows[i][7].ToString();
                sendAddr.Company_name = dt.Rows[i][8].ToString();
                sendAddr.Postcode = dt.Rows[i][9].ToString();
                sendAddr.E_mail = dt.Rows[i][10].ToString();
                sendAddr.Phone = dt.Rows[i][11].ToString();
                sendAddr.Is_default = dt.Rows[i][12].ToString();
                sendAddr.Time = Convert.ToDateTime(dt.Rows[i][13].ToString()) ;

                arr.Add(sendAddr);
            }

            return arr;
        }

        /// <summary>
        /// 通过会员名获取发件人地址信息表
        /// </summary>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        public DataTable getSendTable(string name)
        {
            SqlConnection conn = DBConn.getConn();
            string sql = "select * from tb_senderAddress where name='" + name + "' order by is_default desc,last_use_time desc";
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;
        }

        /// <summary>
        /// 通过地址编号获取地址对象
        /// </summary>
        /// <param name="addr_id"></param>
        /// <returns></returns>
        public SendAddress getSendAddress(int addr_id)
        {
            SendAddress send = new SendAddress();

            string sql = "select * from tb_senderAddress where addr_id="+addr_id;

            DataTable dt = new DBOperateCommon().excuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                send.Addr_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                send.Name = dt.Rows[0][1].ToString();
                send.Sender_name = dt.Rows[0][2].ToString();
                send.Country = dt.Rows[0][3].ToString();
                send.Province = dt.Rows[0][4].ToString();
                send.City = dt.Rows[0][5].ToString();
                send.Area = dt.Rows[0][6].ToString();
                send.Street_info = dt.Rows[0][7].ToString();
                send.Company_name = dt.Rows[0][8].ToString();
                send.Postcode = dt.Rows[0][9].ToString();
                send.E_mail = dt.Rows[0][10].ToString();
                send.Phone = dt.Rows[0][11].ToString();
                send.Is_default = dt.Rows[0][12].ToString();

                send.Time = Convert.ToDateTime(dt.Rows[0][13].ToString());
            }

            return send;

        }

        /// <summary>
        /// 通过发件地址编号获取发件地址
        /// </summary>
        /// <param name="addr_id">发件地址编号</param>
        /// <returns></returns>
        public string getAddressInfo(int addr_id)
        {
            string address = "";

            SendAddress send = getSendAddress(addr_id);

            address = send.Country + send.Province + send.City + send.Area + send.Street_info + send.Company_name;
            address += send.Postcode + "," + send.Phone + "(" + send.Sender_name + "发)";

            return address;
        }




        /// <summary>
        /// 相数据库中添加发件人地址信息
        /// </summary>
        /// <param name="send">发件人地址信息对象</param>
        /// <returns>如果添加成功侧返回 true，否则返回 false</returns>
        public bool addSendAddress(SendAddress send)
        {
            bool flag = false;
            SqlConnection conn = DBConn.getConn();
            string sql = "insert into tb_senderAddress values('" + send.Name + "','" + send.Sender_name + "','" + send.Country+ "','" +
                           send.Province + "','" + send.City + "','" + send.Area + "','" + send.Street_info + "','" +send.Company_name+"','"+
                           send.Postcode+"','"+send.Phone + "','" + send.E_mail +"','"+send.Is_default+"','"+send.Time+ "')";
            conn.Open();

            if (send.Is_default == "1")
            {
                string sql_update = "update tb_senderAddress set is_default='0' where name='" + send.Name + "'";
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

        //更新发件人地址信息
        public bool updateSendAddress(int addr_id, SendAddress send)
        {
            bool flag = false;

            SqlConnection conn = DBConn.getConn();
            string sql = "update tb_senderAddress set sender_name='" + send.Sender_name + "',country='" + send.Country + "',province='" + send.Province
                          + "',city='" + send.City + "',area='" + send.Area + "',street_info='" + send.Street_info +"',company_name='"+send.Company_name
                          +"',postcode='"+send.Postcode+ "',phone='" + send.Phone + "',e_mail='"+ send.E_mail + "',is_default='"+send.Is_default+"',last_use_time='"+send.Time.ToString()+"' where addr_id=" + addr_id;
                          
            conn.Open();

            if (send.Is_default == "1")
            {
                string sql_update = "update tb_senderAddress set is_default='0' where name='" + send.Name + "'";
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
        /// 修改发件人地址信息
        /// </summary>
        /// <param name="send"> 发件人地址对象</param>
        /// <returns>修改成功返回 true , 否则返回 false</returns>
        public bool updateSenderAddress(SendAddress send)
        {
            bool flag = false;
            SqlConnection conn = DBConn.getConn();
            string sql = "update tb_senderAddress set sender_name='" + send.Sender_name + "',country='" + send.Country + "',province='" + send.Province
                          + "',city='" + send.City + "',area='" + send.Area + "',street_info='" + send.Street_info + "',company_name='" + send.Company_name
                          + "',postcode='" + send.Postcode + "',phone='" + send.Phone + "',e_mail='" + send.E_mail + "',is_default='" + send.Is_default + "',last_use_time='" + send.Time.ToString() + "' where addr_id=" + send.Addr_id;
            conn.Open();

            if (send.Is_default == "1")
            {
                string sql_update = "update tb_senderAddress set is_default='0' where name='" + send.Name + "'";
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
        /// 通过 addr_id 删除发件人地址
        /// </summary>
        /// <param name="addr_id">发件人地址编号</param>
        /// <returns>删除成功返回 true，删除失败返回 false</returns>
        public bool deleteSenderAddress(int addr_id)
        {
            bool flag = false;

            string sql = "delete from tb_senderAddress where addr_id=" + addr_id;

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="addr_id">地址编号</param>
        /// <param name="name">会员名</param>
        /// <returns></returns>
        public bool setDefault(int addr_id,string name)
        {
            bool flag = false;

            string sql = "update tb_senderAddress set is_default='0' where name='" + name + "'";
            
            if (new DBOperateCommon().excuteNoQuery(sql))
            {

                string sql1 = "update tb_senderAddress set is_default='1' where addr_id=" + addr_id;
                
                if (new DBOperateCommon().excuteNoQuery(sql1))
                {
                    flag = true;
                }
            }

            return flag;
        }

    }
}