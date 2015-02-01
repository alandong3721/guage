using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WM_Project.control;
using WM_Project.logical.common;

namespace WM_Project.views.inter_express
{
    public partial class simple_batch_order : System.Web.UI.Page
    {
        public  float[] postages;
        public  ArrayList orders = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["name"] == null)
                {
                    alert("请先登录");
                    login_first.Visible = true;
                    page_one.Visible = false;
                }
                else
                {
                    string step = Request.QueryString["step"];

                    if (step == null)
                    {
                        page_one.Visible = true;
                    }
                    else if(step == "2")
                    {
                        ArrayList temporders = (ArrayList)Session["batch_orders"];
                        initPostage(temporders);

                        for (int i = 0; i < temporders.Count; i++)
                        {
                            BatchOrder order = (BatchOrder)temporders[i];
                            BatchOrder newOrder = new BatchOrder();
                            newOrder.Count = order.Count;
                            newOrder.Departure = order.Departure;
                            newOrder.Destination = order.Destination;
                            newOrder.Weight = order.Weight;
                            newOrder.Length = order.Length;
                            newOrder.Width = order.Width;
                            newOrder.Height = order.Height;
                            newOrder.PostWay = getPostWay(order.PostWay);

                            orders.Add(newOrder);
                        }

                        page_two.Visible = true;
                        page_one.Visible = false;
                    }
                }
            }
            
        }


        //////////////////////////////////////////////////////////////////////////
        //登陆的实现

        /// <summary>
        /// 登陆按钮的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    Session["name"] = name;
                    Response.Redirect("simple-batch-order.aspx");

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


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //登陆之后的实现部分

        //询价按钮
        protected void btn_checkPrice_Click(object sender, EventArgs e)
        {
            ArrayList batch_orders = new ArrayList();

            string count = Request.Form["count"];
            string weight = Request.Form["weight"];
            string length = Request.Form["length"];
            string width = Request.Form["width"];
            string height = Request.Form["height"];
            string departure = Request.Form["departure"];
            string destination = Request.Form["destination"];
            string postway = Request.Form["postway"];
            
            
            string[] count_array = count.Split(',');
            string[] weight_array = weight.Split(',');
            string[] length_array = length.Split(',');
            string[] width_array = width.Split(',');
            string[] height_array = height.Split(',');
            string[] departure_array = departure.Split(',');
            string[] destination_array = destination.Split(',');
            string[] postway_array = postway.Split(',');
           
            for (int i = 0; i < weight_array.Length; i++)
            {
                BatchOrder batch_order = new BatchOrder();
                batch_order.Count = Convert.ToInt32(count_array[i]);
                batch_order.Weight = Convert.ToSingle(weight_array[i]);
                batch_order.Length = Convert.ToSingle(length_array[i]);
                batch_order.Width = Convert.ToSingle(width_array[i]);
                batch_order.Height = Convert.ToSingle(height_array[i]);
                batch_order.Departure = departure_array[i];
                batch_order.Destination = destination_array[i];
                batch_order.PostWay = postway_array[i];
                batch_orders.Add(batch_order);
            }

            Session["batch_orders"] = batch_orders;
            
            Response.Redirect("simple-batch-order.aspx?step=2");
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //邮费预览页面的实现
        private void initPostage(ArrayList batch_orders)
        {
            postages = new float[batch_orders.Count];

            for (int i = 0; i < batch_orders.Count;i++ )
            {
                BatchOrder order = (BatchOrder)batch_orders[i];

                int count = order.Count;
                float weight = order.Weight;
                float length = order.Length;
                float width = order.Width;
                float height = order.Height;
                string departure = order.Departure;
                string desitination = order.Destination;
                string postway = order.PostWay;

                postages[i] = count*new InterFaceQuote().getQuote(Session["name"].ToString(),desitination,weight,length,width,height,postway);
                //转换为小数点后只有两位
                postages[i] = (int)(postages[i] * 100) / 100.0f;

            }

            Session["postages"] = postages;
        }


        //弹出提示信息
        private void alert(string message)
        {
            Response.Write(string.Format("<script language='javascript'>alert('{0}');</script>",message));
        }

        protected void btn_BuyNow_Click(object sender, EventArgs e)
        {
            int count = 0;

            ArrayList array = (ArrayList)Session["batch_orders"];

            for (int i = 0; i < array.Count; i++)
            {
                BatchOrder batch_order = (BatchOrder)array[i];
                if (batch_order.PostWay.ToLower().Contains("postnl") || batch_order.PostWay.ToLower().Contains("ems"))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Response.Redirect("simple-batch-purchase-process.aspx");
            }
            else
            {
                Response.Redirect("simple-batch-uk-pick-up.aspx");
            }
        }


        private string getPostWay(string postway)
        {
            string way = "";

            if (postway == "PF-IPE-Collection")
            {
                way = "皇家邮政经济包（上门取件）";
            }
            else if (postway == "PF-IPE-Depot")
            {
                way = "皇家邮政经济包（自行送投至Depot）";
            }
            else if (postway == "PF-IPE-Pol")
            {
                way = "皇家邮政经济包（自行送投至邮局）";
            }
            else if (postway == "PF-GPR-Collection")
            {
                way = "皇家邮政优先包(上门取件)";
            }
            else if (postway == "PF-GPR-Delivery")
            {
                way = "皇家邮政优先包(自行送投至邮局或Depot)";
            }
            else if (postway == "EMS")
            {
                way = "华盟EMS专线";
            }
            else if (postway == "PostNL")
            {
                way = "荷兰邮政优先包";
            }


            return way;
        }
    }
}