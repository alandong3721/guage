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
    public partial class batch_order : System.Web.UI.Page
    {
        public  ArrayList packageTOSameAddress = new ArrayList();
        public  float[] postages;

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
                    else if (step == "2")
                    {
                        page_two.Visible = true;
                        ArrayList temppackageTOSameAddress = (ArrayList)Session["packageTOSameAddress"];
                        initPostages(temppackageTOSameAddress);

                        for (int i = 0; i < temppackageTOSameAddress.Count; i++)
                        {
                            PackagesToSameAddress packagetosame = (PackagesToSameAddress)temppackageTOSameAddress[i];
                            PackagesToSameAddress newpackage = new PackagesToSameAddress();
                            newpackage.Departure = packagetosame.Departure;
                            newpackage.Destination = packagetosame.Destination;
                            newpackage.Package_Array = packagetosame.Package_Array;
                            newpackage.Postway = getPostWay(packagetosame.Postway);
                            packageTOSameAddress.Add(newpackage);
                        }
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
                    Response.Redirect("batch-order.aspx");                   

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

        //询价按钮
        protected void btn_price_query_Click(object sender, EventArgs e)
        {
            packageTOSameAddress = new ArrayList();

            string departure = Request.Form["departure"];
            string destination = Request.Form["destination"];
            string postway = Request.Form["postway"];

            string count = Request.Form["count"];
            string weight = Request.Form["weight"];
            string length = Request.Form["length"];
            string width = Request.Form["width"];
            string height = Request.Form["height"];
            string hidden = Request.Form["hidden"];



            string[] departure_array = departure.Split(',');
            string[] destination_array = destination.Split(',');
            string[] postway_array = postway.Split(',');

            string[] count_array = count.Split(',');
            string[] weight_array = weight.Split(',');
            string[] length_array = length.Split(',');
            string[] width_array = width.Split(',');
            string[] height_array = height.Split(',');
            
            string[] hidden_array = hidden.Split(',');

            int k = 0;

            for (int i = 0; i < departure_array.Length; i++)
            {
                PackagesToSameAddress packages = new PackagesToSameAddress();
                packages.Departure = departure_array[i];
                packages.Destination = destination_array[i];

                packages.Postway = postway_array[i];

                ArrayList package_array = new ArrayList();
                PackageMeasure packageMeasure;

                for (int j = 0; j < Convert.ToInt32(hidden_array[i]); j++)
                {
                    packageMeasure = new PackageMeasure();
                    packageMeasure.Count = Convert.ToInt32(count_array[k]);
                    packageMeasure.Weight = Convert.ToSingle(weight_array[k]);
                    packageMeasure.Length = Convert.ToSingle(length_array[k]);
                    packageMeasure.Width = Convert.ToSingle(width_array[k]);
                    packageMeasure.Height = Convert.ToSingle(height_array[k]);
                    k++;
                    package_array.Add(packageMeasure);
                }
                packages.Package_Array = package_array;

                packageTOSameAddress.Add(packages);
            }

            Session["packageTOSameAddress"] = packageTOSameAddress;
            
            Response.Redirect("batch-order.aspx?step=2");
        }

        //计算邮费
        private void initPostages(ArrayList array)
        {
            postages = new float[array.Count];

            for (int i = 0; i < array.Count; i++)
            {
                float total = 0;
                PackagesToSameAddress temp_package = (PackagesToSameAddress)array[i];
                ArrayList package_measure_array = temp_package.Package_Array;
                
                string departure = temp_package.Departure;
                string destination = temp_package.Destination;
                string postway = temp_package.Postway;

                for (int j = 0; j < package_measure_array.Count; j++)
                {
                    PackageMeasure package_measure = (PackageMeasure)package_measure_array[j];
                    total += package_measure.Count * new InterFaceQuote().getQuote(Session["name"].ToString(), destination, package_measure.Weight, package_measure.Length, package_measure.Width, package_measure.Height, postway);
                }

                postages[i] = (int)(100*total)/100.0f;
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
            ArrayList array = (ArrayList)Session["packageTOSameAddress"];
            int count = 0;
            for (int i = 0; i < array.Count; i++)
            {
                PackagesToSameAddress package = (PackagesToSameAddress)array[i];

                if (package.Postway.ToLower().Contains("postnl") || package.Postway.ToLower().Contains("ems"))
                {
                    count++;
                }
            }

            if (count != 0)
            {
                Response.Redirect("batch-uk-pick-up.aspx");
            }
            else
            {
                Response.Redirect("batch-purchase-process.aspx");
            }
                
        }

        private string getPostWay(string postway)
        {
            string way = "";

            if (postway == "PF-IPE-Collection")
            {
                way = "皇家邮政经济包（上门取件）";
            }
            else if(postway=="PF-IPE-Depot")
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