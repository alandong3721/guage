using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WM_Project.control;
using System.Collections;

namespace WM_Project.views.inter_express
{
    public partial class local_order_pick_up : System.Web.UI.Page
    {
        public  DataTable table = new DataTable();
        public  int pageNow = 0;
        public  int pageSize = 20;
        public  int page_count = 0;
        public  int record_count = 0;

        public  string start_time = "";
        public  string end_time = "";

        public static string message = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["name"] == null)
                {
                    before_login.Visible = true;
                    after_login.Visible = false;
                }
                else
                {
                    string action = Request.Form["action"];
                    string page = Request.Form["pageNow"];

                    if (action == null)
                    {
                        initDataList("default");
                    }
                }

            }

        }



        //登陆按钮的实现
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string name = Request.Form["txt_username"];
            string password = Request.Form["txt_password"];
            string code = Request.Form["txt_code"].ToLower();

            string session_code = Session["code"].ToString().ToLower();

            //身份验证
            if (code.Equals(session_code))
            {
                int flag = new UserDAO().checkUser(name, password);

                //身份验证通过
                if (flag == 1)
                {
                    //通过身份验证
                    Session["name"] = name;
                   
                    Response.Redirect("local-order-pick-up.aspx");
                    
                }
                else if (flag == 0)
                {
                    alert("密码错误！");
                }
                else if (flag == -1)
                {
                    alert("用户名不存在！");
                }
            }
            else
            {
                alert("验证码错误！");
            }
        }


        //按订单号查找
        protected void btn_check_by_order_Click(object sender, EventArgs e)
        {
            string order_no = Request.Form["order_number"];
            if (order_no != null)
            {
                order_no = order_no.Trim();
            }
            DataTable temp = new AutoOrderListDAO().getInnerAutoOrderListTable(order_no);
            if (temp.Rows.Count > 0)
            {
                has_local_order.Visible = true;
                no_local_order.Visible = false;
                local_datalist.DataSource = createTable(temp);
                local_datalist.DataBind();
            }
            else
            {
                has_local_order.Visible = false;
                no_local_order.Visible = true;
                message = "没有找到与该订单号对应的订单信息!!";
            }


        }

        /// <summary>
        /// 按时间查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_check_by_time_Click(object sender, EventArgs e)
        {
            start_time = txt_from.Text.ToString();
            end_time = txt_to.Text.ToString();

            int i = end_time.CompareTo(start_time);

            if (start_time == "" || end_time == "")
            {
                alert("请选择所查询的时间段");
                return;
            }
            else if (end_time.CompareTo(start_time) != 1)
            {
                alert("起始时间不能大于等于终止时间!!");
                return;
            }
            else
            {
                pageNow = 1;
                DataTable temp = new AutoOrderListDAO().getInnerAutoOrderList(Session["name"].ToString(), start_time, end_time, pageNow, pageSize);

                if (temp.Rows.Count > 0)
                {
                    has_local_order.Visible = true;
                    no_local_order.Visible = false;
                    local_datalist.DataSource = createTable(temp);
                    local_datalist.DataBind();
                }
                else
                {
                    has_local_order.Visible = false;
                    no_local_order.Visible = true;
                    message = "没有找到该时间段内的订单!!";
                }

            }
        }

        protected void btn_local_order_Click(object sender, EventArgs e)
        {
            ArrayList order_nombers = new ArrayList();

            string check_box = Request.Form["check"];
            string[] checks = check_box.Split(',');

            new LocalOrderDAO().clearMyShoppingCart(Session["name"].ToString());

            for (int i = 0; i < checks.Length; i++)
            {
                order_nombers.Add(checks[i]);
            }

            Session["local_order"] = order_nombers;

            Response.Redirect("local-order-process.aspx");
        }



        private void initDataList(string type)
        {

            if (type == "default")
            {
                //默认显示用户最近两周下的国际订单,分页显示
                string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                string start = DateTime.Now.AddDays(-13).ToString("yyyy-MM-dd");
                pageNow = 1;
                table = new AutoOrderListDAO().getInnerAutoOrderList(Session["name"].ToString(), pageNow, pageSize, start, end);
                local_datalist.DataSource = createTable(table);
                local_datalist.DataBind();

            }

        }

        /// <summary>
        /// 创建DataList的数据绑定表
        /// </summary>
        /// <param name="table">数据源</param>
        /// <returns></returns>
        private DataTable createTable(DataTable table)
        {
            DataTable table_bind = new DataTable();

            DataColumn dc = new DataColumn("order_number", typeof(string));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("order_count", typeof(int));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("order_weight", typeof(float));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("collection_name", typeof(string));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("delivery_name", typeof(string));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("service_way", typeof(string));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("money_pay", typeof(float));
            table_bind.Columns.Add(dc);

            dc = new DataColumn("pay_time", typeof(string));
            table_bind.Columns.Add(dc);

            foreach (DataRow dr in table.Rows)
            {
                DataRow dr_bind = table_bind.NewRow();
                dr_bind["order_number"] = dr["order_no"].ToString();
                dr_bind["order_count"] = 1;
                dr_bind["order_weight"] = Convert.ToSingle(dr["weight"].ToString());
                dr_bind["collection_name"] = dr["collectioncontactname"].ToString();
                dr_bind["delivery_name"] = dr["recipientcontactname"].ToString();
                dr_bind["service_way"] = dr["servicecode"].ToString();
                dr_bind["money_pay"] = Convert.ToSingle(dr["pay_after_discount"].ToString());
                dr_bind["pay_time"] = dr["pay_time"].ToString();

                table_bind.Rows.Add(dr_bind);

            }

            return table_bind;
        }


        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="message"></param>
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>", message));
        }
    }
}