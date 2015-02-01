using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.control
{
    public class StaffDAO
    {
        //判断工作人员是否存在
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">职工名</param>
        /// <param name="password">密码</param>
        /// <param name="type">类型</param>
        /// <returns>存在返回 1，否则返回 -1</returns>
        public int checkStaff(string name,string password,string type) {

            int flag = 0;
            string sql = "select password from tb_staff where name='"+name+"' and type='"+type+"'";

            DataTable table = new DBOperateCommon().excuteQuery(sql);

            if (table.Rows.Count > 0) {
                for (int i = 0; i < table.Rows.Count; i++) {
                    if (table.Rows[i][0].Equals(password)) {
                        flag = 1;
                        break;
                    }
                }
            }
            else{
                flag = -1;
            }

            return flag;
        
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Staff getStaff(string name,string type)
        {
            Staff staff = new Staff();

            string sql = "select * from tb_staff where name='" + name + "' and type='" + type + "'";
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            if (table.Rows.Count > 0)
            {
                staff.Name = table.Rows[0]["name"].ToString();
                staff.Phone = table.Rows[0]["phone"].ToString();
                staff.Email = table.Rows[0]["email"].ToString();
                staff.Type = table.Rows[0]["type"].ToString();
            }


            return staff;
        }
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="name">员工名</param>
        /// <param name="phone">电话号码</param>
        /// <param name="email">邮箱</param>
        /// <param name="type">类别</param>
        /// <returns>更新成功返回 True, 否则返回 false</returns>
        public bool updateStaff(string name,string phone,string email,string type)
        {
            bool flag = false;

            string sql = "update tb_staff set phone='" + phone + "',email='" + email + "' where name='" + name + "' and type='" + type + "'";

            if (new DBOperateCommon().excuteNoQuery(sql))
            {
                flag = true;
            }

            return flag;
        }



        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="staff_name">员工名</param>
        /// <returns></returns>
        public bool deleteStaff(int staff_id)
        {
            bool flag = false;

            string del = "delete from tb_staff where staff_id=" + staff_id ;

            if (new DBOperateCommon().excuteNoQuery(del))
            {
                flag = true;
            }

            return flag;
        }



        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="staff_name">员工名</param>
        /// <returns></returns>
        public bool deleteStaff(string staff_name)
        {
            bool flag = false;

            string del = "delete from tb_staff where name='" + staff_name + "' and type='staff' or type='manager'";
            
            if (new DBOperateCommon().excuteNoQuery(del))
            {
                flag = true;
            }

            return flag;
        }

        /// <summary>
        /// 获取员工信息表
        /// </summary>
        /// <returns></returns>
        public DataTable getStaffs(int pageNow,int pageSize)
        {
         
            string sql = "select top "+pageSize+" * from tb_staff where type='staff' or type='manager' and staff_id not in(select top "+(pageNow-1)*pageSize+" staff_id from tb_staff where type='staff' or type='manager' order by time asc) order by time asc";
           
            DataTable table = new DBOperateCommon().excuteQuery(sql);
            
            return table;
        }


        //获取员工的个数
        public int getStaffCount()
        {
            int count = 0;

            string sql = "select count(*) from tb_staff where type='staff' or type='manager'";
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
        /// <param name="recordCount">记录条数</param>
        /// <param name="pageSize">每页显示的条数</param>
        /// <returns></returns>
        public int getPageCount(int recordCount ,int pageSize)
        {
            int page_count = 0;

            if(recordCount%pageSize==0)
            {
                page_count = recordCount / pageSize;
            }
            else
            {
                page_count = recordCount / pageSize + 1;
            }

            return page_count;
        }
    }
}